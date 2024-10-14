﻿using System.Security.Cryptography;
using System.Text;
using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;
using BinhDinhFood.Models.Authentication;
using BinhDinhFood.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFood.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BinhDinhFoodDbContext _context;
    private readonly IWebHostEnvironment _appEnvironment;

    public UserRepository(BinhDinhFoodDbContext context, IWebHostEnvironment appEnvironment)
    {
        _context = context;
        _appEnvironment = appEnvironment;
    }
    private string Encode(string originalPassword)
    {
        MD5 md5 = MD5.Create();
        byte[] originalBytes = Encoding.Default.GetBytes(originalPassword);
        byte[] encodedBytes = md5.ComputeHash(originalBytes);

        return BitConverter.ToString(encodedBytes);
    }
    private string ReturnToken(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
        }

        if (string.IsNullOrEmpty(allowedChars))
        {
            throw new ArgumentException("allowedChars may not be empty.");
        }

        const int byteSize = 0x100;
        var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
        if (byteSize < allowedCharSet.Length)
        {
            throw new ArgumentException(string.Format("allowedChars may contain no more than {0} characters.", byteSize));
        }

        // Guid.NewGuid and System.Random are not particularly random. By using a
        // cryptographically-secure random number generator, the caller is always
        // protected, regardless of use.
        using (var rng = RandomNumberGenerator.Create())
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
                    var outOfRangeStart = byteSize - byteSize % allowedCharSet.Length;
                    if (outOfRangeStart <= buf[i])
                    {
                        continue;
                    }

                    result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                }
            }
            return result.ToString();
        }
    }
    private Customer GetCustomer(int id)
    {
        return _context.Customers.Find(id);
    }
    public InforViewModel GetUserInfor(int id)
    {
        var user = GetCustomer(id);
        InforViewModel model = new InforViewModel();
        return new InforViewModel
        {
            FullName = user.CustomerFullName,
            Address = user.CustomerAddress,
            Phone = user.CustomerPhone,
            Image = user.CustomerImage,
            Email = user.CustomerEmail
        };
    }
    private Customer GetCustomer(string userName)
    {
        return _context.Customers.FirstOrDefault(user => user.CustomerUserName == userName);
    }
    public CookieUserItem Validate(LoginViewModel model)
    {
        var userRecords = _context.Customers.Where(x => x.CustomerUserName == model.UserName);

        var results = userRecords.AsEnumerable()
        .Where(m => m.CustomerPassword == Encode(model.Password))
        .Select(m => new CookieUserItem
        {
            Id = m.CustomerId,
            Email = m.CustomerEmail,
            UserName = m.CustomerUserName,
            Role = "Customer"
        });

        return results.FirstOrDefault();
    }
    public CookieUserItem Register(RegisterViewModel model)
    {
        var user = new Customer
        {
            CustomerFullName = model.FullName,
            CustomerUserName = model.UserName,
            CustomerPassword = Encode(model.Password),
            CustomerEmail = model.Email,
            CustomerAddress = model.Address,
            CustomerImage = "avatar.jpg",
            CustomerPhone = "0900000000"
        };
        _context.Customers.Add(user);
        _context.SaveChanges();

        return new CookieUserItem
        {
            Id = user.CustomerId,
            UserName = user.CustomerUserName,
            Email = user.CustomerEmail,
            Role = "Customer"
        };
    }
    public string CreateResetPasswordLink(string customerUserName)
    {
        string token = ReturnToken(64);
        Token toKen = new Token(customerUserName, token, DateTime.Now.AddMinutes(2));
        _context.Tokens.Add(toKen);
        _context.SaveChanges();
        return "http://binhdinhfood-001-site1.dtempurl.com/User/ResetPassword?user=" + customerUserName + "&token=" + token;
    }
    public async Task<bool> HaveAccount(ForgotViewModel model)
    {
        return await _context.Customers.AnyAsync(x => x.CustomerUserName == model.UserName && x.CustomerEmail == model.Email);
    }
    public async Task<bool> HaveAccount(string userName, string password)
    {
        return await _context.Customers.AnyAsync(_context => _context.CustomerUserName == userName && _context.CustomerPassword == Encode(password));
    }
    public async Task ResetPassWord(ResetViewModel model)
    {
        var customer = GetCustomer(model.UserName);
        customer.CustomerPassword = Encode(model.Password);
        await _context.SaveChangesAsync();
    }
    public async Task ChangeInforUser(InforViewModel model, int id, IFormFileCollection files)
    {
        var user = GetCustomer(id);
        user.CustomerFullName = model.FullName;
        user.CustomerEmail = model.Email;
        user.CustomerPhone = model.Phone;
        //user.CustomerImage = model.Image;
        user.CustomerAddress = model.Address;

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
    public async Task ChangePasswordUser(ChangePasswordViewModel model, int id)
    {
        var user = GetCustomer(id);
        user.CustomerPassword = Encode(model.NewPassword);
        await _context.SaveChangesAsync();
    }
}
