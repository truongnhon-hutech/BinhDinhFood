using BinhDinhFood.Models;
using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BinhDinhFoodWeb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BinhDinhFoodDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public UserRepository(BinhDinhFoodDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        private string Encode(string originalPassword)
        {
            MD5 md5 = MD5.Create();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
        private string ReturnToken(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }
        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }
        public ChangeInforViewModel GetUserInfor(int id)
        {
            var user = GetCustomer(id);
            ChangeInforViewModel model = new ChangeInforViewModel();
            return new ChangeInforViewModel
            {
                CustomerFullName = user.CustomerFullName,
                CustomerAddress = user.CustomerAddress,
                CustomerPhone = user.CustomerPhone,
                CustomerImage = user.CustomerImage,
                CustomerEmail = user.CustomerEmail
            };
        }
        private Customer GetCustomer(string userName)
        {
            return _context.Customers.FirstOrDefault(user => user.CustomerUserName == userName);
        }
        public CookieUserItem Validate(LoginViewModel model)
        {
            var userRecords = _context.Customers.Where(x => x.CustomerUserName == model.CustomerUserName);

            var results = userRecords.AsEnumerable()
            .Where(m => m.CustomerPassword == Encode(model.CustomerPassword))
            .Select(m => new CookieUserItem
            {
                CustomerId = m.CustomerId,
                CustomerEmail = m.CustomerEmail,
                CustomerUserName = m.CustomerUserName
            });

            return results.FirstOrDefault();
        }
        public CookieUserItem Register(RegisterViewModel model)
        {
            var user = new Customer
            {
                CustomerFullName = model.CustomerFullName,
                CustomerUserName = model.CustomerUserName,
                CustomerPassword = Encode(model.CustomerPassword),
                CustomerEmail = model.CustomerEmail,
                CustomerAddress = model.CustomerAddress,
                CustomerImage = "avatar.jpg",
                CustomerPhone = "0905726748"
            };
            _context.Customers.Add(user);
            _context.SaveChanges();

            return new CookieUserItem
            {
                CustomerId = user.CustomerId,
                CustomerUserName =user.CustomerUserName,
                CustomerEmail = user.CustomerEmail,
            };
        }
        public string CreateResetPasswordLink(string customerUserName)
        {
            string token = ReturnToken(64);
            Token toKen = new Token(customerUserName, token, DateTime.Now.AddMinutes(2));
            _context.Tokens.Add(toKen);
            _context.SaveChanges();
            return "https://localhost:44316/User/ResetPassword?user=" + customerUserName + "&token=" + token;
        }
        public async Task<bool> HaveAccount(ForgotViewModel model)
        {
            return await _context.Customers.AnyAsync(x => x.CustomerUserName == model.CustomerUserName && x.CustomerEmail == model.CustomerEmail);
        }
        public async Task<bool> HaveAccount(string userName,string password)
        {
            return await _context.Customers.AnyAsync(_context => _context.CustomerUserName == userName && _context.CustomerPassword == Encode(password));
        }
        public async Task ResetPassWord(ResetViewModel model)
        {
            var customer = GetCustomer(model.CustomerUserName);
            customer.CustomerPassword = Encode(model.CustomerPassword);
            await _context.SaveChangesAsync();
        }
        public async Task ChangeInforUser(ChangeInforViewModel model,int id, IFormFileCollection files)
        {
            var user = GetCustomer(id);
            user.CustomerFullName = model.CustomerFullName;
            user.CustomerEmail = model.CustomerEmail;
            user.CustomerPhone = model.CustomerPhone;
            //user.CustomerImage = model.CustomerImage;
            user.CustomerAddress = model.CustomerAddress;

            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "Content\\img\\staff\\");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            user.CustomerImage = fileName;
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task ClearImage(int id)
        {
            var user = GetCustomer(id);
            user.CustomerImage = "avatar.jpg";
            await _context.SaveChangesAsync();
        }
        public async Task ChangePasswordUser(ChangePasswordViewModel model,int id)
        {
            var user = GetCustomer(id);
            user.CustomerPassword = Encode(model.NewPassword);
            await _context.SaveChangesAsync();
        }
    }
}
