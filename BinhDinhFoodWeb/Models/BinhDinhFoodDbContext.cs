﻿using BinhDinhFood.Models.Authentication;
using BinhDinhFood.Models.Entities;
using BinhDinhFood.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BinhDinhFood.Models;

public class BinhDinhFoodDbContext(DbContextOptions<BinhDinhFoodDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductRating> ProductRatings { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Blog> Blog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Admin>().ToTable("Admin");
        modelBuilder.Entity<Order>().ToTable("Order");
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<ProductRating>().ToTable("ProductRating");
        modelBuilder.Entity<Banner>().ToTable("Blog");
        modelBuilder.Entity<Token>().ToTable("Token");
        modelBuilder.Entity<Banner>().ToTable("Banner");
        modelBuilder.Entity<Favorite>().ToTable("Favorite");

        modelBuilder.Entity<OrderDetail>()
            .HasKey(c => new { c.ProductId, c.OrderId });

        modelBuilder.Entity<Order>()
            .HasMany(e => e.OrderDetails);

        modelBuilder.Entity<Product>()
            .HasMany(e => e.OrderDetails);

        modelBuilder.Entity<Favorite>()
           .HasKey(c => new { c.ProductId, c.CustomerId });

        modelBuilder.Entity<Customer>()
            .HasMany(e => e.Favorites);

        modelBuilder.Entity<Product>()
            .HasMany(e => e.Favorites);

        modelBuilder.Entity<Product>()
            .HasMany(g => g.ProductRatings);

        modelBuilder.Entity<Customer>()
            .HasMany(g => g.ProductRatings);

        modelBuilder.Entity<Product>()
           .HasMany(g => g.Favorites);

        modelBuilder.Entity<Customer>()
            .HasMany(g => g.Favorites);

        modelBuilder.Entity<Admin>()
            .HasIndex(g => g.AdminUserName)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(g => g.CustomerUserName)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            ProductName = "Chả cá Quy Nhơn",
            ProductPrice = 120000,
            ProductDescription = "Mặc dù chả cá có thể là đặc sản và có mặt ở nhiều nơi nhưng không phải hương vị chả cá nào cũng như nhau. Sở dĩ chả cá Quy Nhơn là một trong các đặc sản Bình Định nổi tiếng vì vị ngon và lạ đặc trưng. Với nguyên liệu được tuyển chọn từ những con cá biển tươi ngon nhất và công thức chế biến độc quyền của người dân đã tạo nên sự khác biệt cho chả cá Quy Nhơn.\n Chả cá Quy Nhơn phổ biến có 2 loại là chả hấp và chả chiên. Ngoài việc thưởng thức thực tiếp miếng chả dai, giòn, thơm ngon đặc biệt, các bạn có thể dùng chả cá này để làm “topping” cho các món ăn khác như cơm, bún, phở. Đây cũng là một lựa chọn thích hợp để bạn mua về làm quà cho người thân và bạn bè nữa đó.",
            ProductAmount = 100,
            ProductDiscount = 10,
            ProductRating = 0,
            ProductImage = "chaca.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 6,
            ProductName = "Tôm khô",
            ProductPrice = 84000,
            ProductDescription = "Tôm khô còn gọi là tôm nõn khô là một trong các loại thực phẩm giàu dinh dưỡng rất tốt cho sức khỏe. Chúng được làm từ tôm tươi tự nhiên và phơi khô dưới ánh nắng mặt trời hoặc sấy khô thủ công. 1kg tôm tươi làm được khoảng 2 lạng tôm khô, thành phẩm tôm có kích thước nhỏ hơn, có vị ngọt thanh đậm đà rất thơm.\nGiá trị dinh dưỡng của tôm vẫn giữ gần như nguyên vẹn, trong 100g tôm khô có: 347 kcal, 75,6g đạm, 235mg canxi, 4,6mg sắt, vitamin B1, B2, PP và 3,8g chất béo chưa bảo hòa.",
            ProductAmount = 20,
            ProductDiscount = 20,
            ProductRating = 0,
            ProductImage = "tom-kho-gia-bao-nhieu-1kg.jpg",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 7,
            ProductName = "Mắm Nhum Mỹ An Bình Định",
            ProductPrice = 20000,
            ProductDescription = "Nhum có rất nhiều loại khác nhau, nhưng mắm nhum tại Bình Định đặc biệt được làm từ con nhum ta, tạo hương vị ngon đến nỗi “ăn với món gì cũng ngon”. Đồng thời mắm Nhum tại Mỹ An cũng từng là đặc sản Bình Định được tiến vua, và hiện nay là một món ăn mà du khách không thể bỏ lỡ khi đến Bình Định du lịch.\nNhum vốn là động vật với bê ngoài gai góc có thể làm đau người dân nếu đạp phải, và người dân nơi đây đã biến chúng thành một món ngon tuyệt vời. Mắm nhum còn có thể là món quà hảo hạng giúp bạn dùng làm quà tặng sau khi đến Bình Định du lịch, nếu được thì bạn nên đến Mỹ An để mua mắm nhum nhé.",
            ProductAmount = 100,
            ProductDiscount = 5,
            ProductRating = 0,
            ProductImage = "mamnhum.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 7
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 16,
            ProductName = "Cá cơm khô",
            ProductPrice = 18000,
            ProductDescription = "cá cơm giàu vitamin A, nhiều axit béo, vitamin E, canxi, Vitamin A, giúp mắt sáng, ngăn ngừa các bệnh về mắt, duy trì làn da khỏe mạnh. Ăn cá cơm giúp giảm lượng cholesterol trong máu, ngăn ngừa các bệnh về tim mạch.\nCá cơm cung cấp một lượng lớn protein và đạm, nên chúng được sử dụng để làm nước mắm nhĩ",
            ProductAmount = 55,
            ProductDiscount = 15,
            ProductRating = 0,
            ProductImage = "cach-lam-ca-kho-tam-gia-vi.jpg",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 17,
            ProductName = "Nem chợ huyện",
            ProductPrice = 150000,
            ProductDescription = "Nem chua là một trong các đặc sản Bình Định được chế biến cầu kỳ và công phu. Với công thức hương vị đặc biệt để ướp những miếng thịt heo tươi ngon nhất và gói bên trong những lớp lá khế non và lớp lá chuối cầu kì, hương vị thơm ngon nổi tiếng của nem chợ huyện cũng từ đó mà vang xa.\nĐến Bình Định ngồi cắn một miếng nem và nhâm nhi một ít rượu Bàu Đá cũng đủ để bạn nhớ về hương vị ấy mỗi khi nhắc đến chuyến du lịch này đó. Ngoài ra, nem cũng là lựa chọn thích hợp để làm quà tặng, với hương vị tuyệt vời ấy ai lại lỡ không thích món quà mà bạn tặng.",
            ProductAmount = 100,
            ProductDiscount = 20,
            ProductRating = 0,
            ProductImage = "nem.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 18,
            ProductName = "Bánh ít lá gai",
            ProductPrice = 100000,
            ProductDescription = "“Muốn ăn bánh ít lá gai Lấy chồng Bình Định sợ dài đường đi\"Bánh ít lá gai là một trong các đặc sản Bình Định nổi tiếng. Để làm nên những chiếc bánh ít thơm ngon nức tiếng, người làm bánh phải lựa chọn và chuẩn bị những chiếc lá gai rất cầu kỳ vì đây là yếu tố quan trong quyết định đến hương vị của bánh. Kế đến là nếp và nhân cũng được lựa chọn và chế biến từ những nguyên liệu ngon nhất.\n Sau một quá trình xay bột, làm nhân, gói và hấp bánh, những chiếc bánh ít lá gai thơm ngon, dẻo dai với vị ngọt của nhân đậu xanh hoặc nhân dừa đã được ra lò. Với đặc sản này bạn nên thử ít nhất một lần, và đây cũng được xem là một món quà mà chắc chắn người thân của bạn sẽ thích.",
            ProductAmount = 100,
            ProductDiscount = 10,
            ProductRating = 0,
            ProductImage = "banhit.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 19,
            ProductName = "Mực rim Quy Nhơn",
            ProductPrice = 150000,
            ProductDescription = "Mực rim là món ăn phổ biến khiến du thích yêu thích có mặt ở hầu hết những vùng biển lớn. Tuy nhiên mực rim hay còn gọi là mực ngào Bình Định có một hương vị thơm ngon rất riêng từ vùng biển duyên hải miền Trung. Mực rim Quy Nhơn được người dân làm từ những con mực tươi nhất và hương vị không nơi nào giống được.\n Với hương thơm ngon đặc biệt cùng vị cay cay kích thích vị giác, mực rim trở thành món ăn vặt siêu ngon và được mọi người vô cùng yêu thích. Đồng thời, với những hũ mực rim được làm sẵn giúp bạn có thể dễ dàng lựa chọn đặc sản Bình Định này để làm quà tặng.",
            ProductAmount = 100,
            ProductDiscount = 5,
            ProductRating = 0,
            ProductImage = "mucrim.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 20,
            ProductName = "Chả Tré rơm",
            ProductPrice = 35000,
            ProductDescription = "Với tên gọi độc và lạ của món Chả Tré, món đặc sản Bình Định này đã gợi nên sự tò mò với nhiều du khách muốn tìm hiểu và được thử món ăn độc đáo này. Mặc dù đã có mặt phổ biến khắp các tỉnh thành Trung Trung bộ, nhưng hương vị thơm ngon nhất vẫn là chả Tré Bình Định với cách làm và công thức chỉ vùng đất Bình Định mới làm nên được.\n Thành phần nguyên liệu làm chả Tré cũng tương tự với các loại nem, bì của miền bắc. Nhưng Tré Bình Định được người dân nơi đây khéo léo thay thế bằng nhiều loại nguyên liệu khác như tai heo, lỗ mũi heo, da heo, thịt ba chỉ,...Tré cũng thích hợp để trở thành món quà mang về khi bạn đến thăm Bình Định.",
            ProductAmount = 100,
            ProductDiscount = 20,
            ProductRating = 3,
            ProductImage = "chatre.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 7
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 21,
            ProductName = "Bánh thuẫn",
            ProductPrice = 15000,
            ProductDescription = "Nếu như Hà Nội có bánh cốm, Hải Dương có bánh đậu xanh, Vũng Tàu có bánh bông lan trứng muối,...và những loại bánh làm quà đặc trưng của nhiều tỉnh khác thì Quy Nhơn lại bánh thuẫn nổi tiếng để làm quà tặng cho người thân và bạn bè. Đây cũng là loại bánh phổ biến vào ngày Tết của người dân miền Trung.\n Bánh thuẫn có vị thơm ngon từ nguyên liệu như trứng gà, bột năng, bột bình tinh, đường, đâu ăn, vani và đặc biệt là khuôn đúc bánh. Quá trình đúc bánh bằng than đã góp phần tạo nên được mùi thơm đặc trưng của đặc sản Bình Định này.",
            ProductAmount = 100,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "banhthuan.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 22,
            ProductName = "Rượu Bầu đá",
            ProductPrice = 40000,
            ProductDescription = "Sở dĩ rượu Bàu đá được biết đến là một trong những đặc sản Bình Định nổi tiếng vì đây là loại rượu không nấu từ gạo thông thường như những loại rượu khác. Rượu Bàu đá Bình Định được nấu từ gạo lứt và chỉ khi sử dụng một nguồn nước trong một làng của tỉnh Bình Định mới đạt được hương vị ngon nhất.\n Từ xưa, rượu Bàu đá đã được tiến cung cho vua nên được xếp vào loại đặc sản thượng hạng của Bình Định. Rượu nổi tiếng dễ say vì có độ cồn rất cao, lên đến 50. Nhưng điều khiến người ta yêu thích hương vị của rượu là vị thanh mát mang lại cảm giác sảng khoái vô cùng. Đây cũng là một món quà thích hợp thể hiện sự kính trọng bạn có thể chọn.",
            ProductAmount = 100,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "ruoubauda.png",
            ProductDateCreated = DateTime.Parse("2022-08-19"),
            CategoryId = 7
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 23,
            ProductName = "Mực ngào Bình Định",
            ProductPrice = 250000,
            ProductDescription = "Một trong những món ăn phải kể đến đầu tiên trong dah sách những món đặc sản Bình Định đó chính là mực ngào. Mực ngào có một hương vị thơm ngon rất riêng thu hút khách du lịch. Để chế biến được món mực ngào người đầu bếp đã phải rất công phu, tài tình tỉ mỉ chăm chút cho món ăn. Mực sau khi đươc thu mua từ những cảng hải sản tươi ngon được đem về sơ chế và chế biến luôn để giữ được độ tươi ngon nguyên vẹn  của mực.\nMực được  ướp cùng tiêu, tỏi, ớt, mắm và một số loại gia vị khác để tạo độ thơm ngon đặc trưng của mực. Món ăn này có vị cay đặc trưng, thơm thơm của các loại gia vị sẽ làm bạn thích thú và muốn ăn ngay từ cái nhìn đầu tiên. Gía của một cân mực ngào giao động từ  200.000 – 400.000 đồng.",
            ProductAmount = 100,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "muc-ngao-ot-dac-san-binh-dinh-lam-qua.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 27,
            ProductName = "Khô cá chỉ vàng",
            ProductPrice = 135000,
            ProductDescription = "Cá chỉ vàng là loài cá nước mặn (còn gọi là cá ngân chỉ) thức ăn của chúng là những sinh vật nổi. Thân cá dẹp hình thoi, hai bên có một sọc vàng chạy thẳng từ sau mắt đến gần vây đuôi, phần lưng màu xanh xám, bụng trắng bạc, trên mang cá có chấm đen, vây đuôi vàng, đầu cá hơi nhọn, miệng chếch, hàm dưới nhô ra.\n Cá chỉ vàng thịt trắng có vị ngọt thơm, giàu vitamin B, Omega 3 giúp ngăn ngừa bệnh tim mạch, tốt cho não bộ, cải thiện giấc ngủ...",
            ProductAmount = 100,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "cach-lua-ca-chi-vang-kho-ngon.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 28,
            ProductName = "Bánh tráng nước dừa",
            ProductPrice = 120000,
            ProductDescription = "Khi đến du lịch Bình Định không thể không nhắc tới  món bánh tráng nước dừa. Đây là một món đặc sản nơi xứ dừa. Công đoạn chế biến bánh không quá cầu kì nhưng đòi hỏi sự tỉ mỉ, có kinh nghiệm của người tráng bánh. Nguyên liệu của bánh chủ yếu là Củ Mì ( củ sắn) được sắt nhỏ, xay lấy nước. Cơm dừa được nạo thành sợi nhỏ,  nước dừa và vừng đen. Tất cả đều được đổ chung vào một nồi lớn, trộn đều cho các gia vị hòa quyện cùng với nhau và được đun nóng. Bên cạnh đó có một chảo đang được đun nóng. Khi chảo nóng lên người tráng bánh sẽ dùng một cái gáo làm bằng sọ dừa có cán dài múc từng gáo nước bánh lên chảo và tráng đều. Tráng bánh phải đều tay để cơm dừa và vừng đen được dàn đều mặt bánh. Bánh phải tròn mỏng và không bị chỗ dày, chỗ mỏng thì mới là bánh đạt chuẩn. cứ tráng được mười chiếc  bánh thì đem ra phơi. khi ăn bạn cần nướng lên để bánh có độ phồng và dậy hết mùi thơm của vừng, của nước cốt dừa và cơm dừa. Có thể ăn bánh thay cơm ăn chỉ thấy no mà không thấy chán.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "Banh-trang-nuoc-dua-am-thuc-binh-dinh.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 29,
            ProductName = "Nước mắm nhĩ Bình Định",
            ProductPrice = 95000,
            ProductDescription = "Nước mắm nhĩ hay nhỉ còn gọi là nước mắm kéo lù hoặc mắm cốt, là loại nước mắm được hứng từ các giọt nước mắm đầu tiên được “nhỉ” ra. Hay nói cách khác là rò rỉ ra từng giọt, từng giọt từ lỗ van đang đóng kín ở đáy của thùng hay lu vại đang muối cá đã đến thời gian chín có thể lấy nước mắm thành phẩm.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "nuoc-mam-nhi-nguyen-chat-tam-quan-binh-dinh.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 30,
            ProductName = "Ruốt khô",
            ProductPrice = 200000,
            ProductDescription = "Con ruốc còn gọi là tép biển, tép moi, ở Việt Nam được coi là đặc sản. Chúng là động vật giáp xác 10 chân sống ở vùng nước mặn ven biển hay nước lợ. Ruốc dạng như tôm nhỏ, chỉ lớn khoảng 10–40 mm Do kích thước của con ruốc biển nhỏ, nên thường được dùng để làm nước mắm ruốc (là một loại mắm đặc sản của miền biển) hoặc phơi khô ruốc để chế biến thành các món ăn dân dã đậm đà hương vị biển.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "các-món-từ-ruốc-khô.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 31,
            ProductName = "Cá Lao Khô Tẩm Gia Vị",
            ProductPrice = 125000,
            ProductDescription = "Hải sản Quy Nhơn nổi tiếng khắp cả nước với nhiều loại hải sản phong phú đa dạng, trong đó Cá lao là một loại hải sản khô đặc biệt thơm ngon, chúng là một loại cá biển, sau khi được ngư dân đánh bắt được xẻ thịt, phơi khô tạo nên một loại thực phẩm thơm ngon đúng chất tinh túy từ biển.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "cá-lao-khô-quy-nhơn.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 32,
            ProductName = "Bánh hồng Tam Quan",
            ProductPrice = 200000,
            ProductDescription = "Bánh hồng Tam Quan là một trong những món đặc sản của Bình Định, được xem như biểu trưng cho tin vui, thường xuất hiện trong các dịp cưới hỏi của người dân nơi đây.\n Điều đặc biệt bánh hồng Tam Quan là bánh được làm từ gạo nếp Ngự nổi tiếng dẻo thơm. Do hoàn toàn không có chất bảo quản nên bánh chỉ để được 5 ngày thôi bạn nhé.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "banhhong.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 33,
            ProductName = "Bánh tráng chả cá",
            ProductPrice = 400000,
            ProductDescription = "Bánh tráng chả cá là một trong những đặc sản nổi tiếng gần xa của Bình Định. Bánh tráng chả cá được làm từ nguyên liệu chính là cá cùng một ít gia vị và bột năng. Để món ăn đúng vị hơn bạn nên ăn kèm với rau răm nhé.",
            ProductAmount = 50,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "banhtrangchaca.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 6
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 34,
            ProductName = "Mực ngào vị tỏi",
            ProductPrice = 200000,
            ProductDescription = "Nếu đã đến với đất Bình Định thì bạn nhất định phải thử qua món mực ngào vị tỏi nhé. Món ăn là sự hòa quyện giữa vị mực vừa tươi vừa giòn cùng vị cay đặc trưng của ớt và tỏi. Bạn nhớ bảo quản món này ở nhiệt độ thoáng mát nha.",
            ProductAmount = 100,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "muc-ngao-ot-dac-san-binh-dinh-lam-qua.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-03"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 35,
            ProductName = "Chả ram tôm đất",
            ProductPrice = 890000,
            ProductDescription = "Chả ram tôm đất là một trong những món ngon đặc sản nổi tiếng của miền đất võ Bình Định, món ăn này phù hợp với mọi lứa tuổi, từ già đến trẻ đều yêu thích và thường xuyên xuất hiện trong các bữa cơm gia đình.\n Miếng chả ram tôm đất Bình Định giòn tan của lớp bánh tráng chiên bên ngoài, bên trong có thịt tôm ngọt tự nhiên, một chút ngầy ngậy của thịt mỡ, tất cả tạo nên hương vị đặc biệt hấp dẫn, gây nghiện cho thực khách khi dùng thử món ăn độc đáo này.",
            ProductAmount = 45,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "chả-ram-tôm-đất-quy-nhơn-ngon-loại-1.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 36,
            ProductName = "Ghẹ sữa rim tỏi ớt, rang me, chiên giòn",
            ProductPrice = 90000,
            ProductDescription = "Ghẹ sữa là ghẹ còn non có kích thước nhỏ, cỡ ngón chân cái người lớn, nhiều nhất vào tháng 5 đến tháng 11, thời điểm ghẹ sinh sản nhiều.\nGhẹ sữa có hàm lượng dinh dưỡng cao, nhiều canxi, đạm, sắt, các vitamin A, B1, B2, C và đặc biệt là magnesium, calcium và axit béo omega 3, có lợi cho sức khỏe và rất tốt cho người có vấn đề tim mạch và hỗ trợ tăng trưởng chiều cao cho trẻ.",
            ProductAmount = 44,
            ProductDiscount = 15,
            ProductRating = 4,
            ProductImage = "ghe-sua-chien-gion.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 37,
            ProductName = "Mực một nắng",
            ProductPrice = 500000,
            ProductDescription = "Mực một nắng là loại hải sản đặc biệt, để làm mực 1 nắng được ngon, sau khi xẻ phải rửa mực tươi bằng nước biển, rồi phơi dưới trời nắng gắt. Chỉ được phơi qua một nắng để mực vẫn giữ được độ tươi ngon, bên ngoài ráo nước, bên trong dẻo và giòn. \nNhững vùng biển có nước biển càng mặn thì mực 1 nắng sẽ càng ngon, đặc biệt là các khu vực miền Trung. Mực một nắng có nhiều loại, nhưng mực ngon nhất vẫn là làm từ những con mực ống và mực lá.\nĐây là một trong các đặc sản nổi tiếng của Bình Định được du khách tìm mua làm quà.",
            ProductAmount = 50,
            ProductDiscount = 20,
            ProductRating = 2,
            ProductImage = "muc-mot-nang-gia-bao-nhieu-1kg.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 38,
            ProductName = "Cá đù một nắng",
            ProductPrice = 16000,
            ProductDescription = "Cá đù hay Cá lù đù là một họ cá thuộc bộ Cá vược (Perciformes) có kích thước lớn, chúng sống ở vùng biển nhiệt đới, cận nhiệt đới. Tại vùng biển Việt Nam, có khoảng 270 loài trong 70 chi, đáng kể nhất là cá lù đù bạc chiếm số lượng lớn trong 20 loài như cá lù đù măng đen, cá lù đù lỗ tai đen, cá lù đù kẽm, cá lù đù sóc, cá lù đù đỏ dạ...\nChúng sống thành từng đàn lớn ở gần bờ, thường núp trong những rạn, hốc đá. Thức ăn của chúng là các loại động vật thủy sinh, côn trùng hay cá nhỏ, giáp xác.\n Vì muốn dự trữ được lâu nên sau khi được đánh bắt, ngư dân chọn cá tươi làm sạch, xẻ lóc bỏ xương, bỏ đầu để ráo. Sau đó, đem phơi khô dưới 1 nắng gắt để cá se lại để thịt dẻo dẻo. Hoặc có thể phơi cho thật khô để dự trữ ăn dần.\n Cá đù 1 nắng phần thân sau của cá có nhiều mỡ, rất béo. Loại cá này có vị ngọt dịu deo dẻo và đặc biệt thịt mềm, hậu bùi, có thể chế biến thành nhiều món ngon hấp dẫn. \nHiện nay, đây là đặc sản được rất nhiều người săn lùng, kể cả người nước ngoài cũng rất thích thú với vị ngon ngọt của nó “đặc biệt là giá cả phải chăng”.",
            ProductAmount = 12,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "cá-đù-một-nắng.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 39,
            ProductName = "Chả Bò (Giò Bò) Bình Định Chính Gốc – Cây 500G",
            ProductPrice = 180000,
            ProductDescription = "Chả Bò (Giò Bò) Bình Định Chính Gốc – Cây 500G",
            ProductAmount = 15,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "cha-bo-binh-dinh-nha-lam.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 7
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 40,
            ProductName = "Bánh Tráng Nhúng Giòn Phù Mỹ",
            ProductPrice = 45000,
            ProductDescription = "Đến với Bình Định, du khách sẽ được thưởng thức những món được làm từ các loại bánh tráng. Nào là bánh tráng mè nướng, bánh tráng nước cốt dừa Tam Quan hay bánh tráng bột mì nhứt nướng, bánh tráng gạo nhúng, … loại bánh nào cũng ngon nhứt nách. Hôm nay, Đặc Sản Bình Định Online xin được giới thiệu đến quý khách một loại bánh tráng độc đáo hơn cả đó là bánh tráng nhúng giòn Phù Mỹ. Hãy cùng khám phá bạn nhé. Nếu có cơ hội đến Bình Định hãy thử một lần thưởng thức loại bánh tráng đặc sản Phù Mỹ để tự cảm nhận hương vị thơm ngon đặc trưng của nó nhé.",
            ProductAmount = 20,
            ProductDiscount = 0,
            ProductRating = 0,
            ProductImage = "banh-trang-nhung-binh-dinh.jpg",
            ProductDateCreated = DateTime.Parse("2022-09-06"),
            CategoryId = 6
        });


        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 1,
            CategoryName = "Đồ khô",
            CategoryDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 6,
            CategoryName = "Bánh truyền thống",
            CategoryDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 7,
            CategoryName = "Đồ đặc sản",
            CategoryDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 1,
            CustomerFullName = "Võ Thương Trường Nhơn",
            CustomerUserName = "truongnhon",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-08-19"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "48/29/8 Lê Văn Hưng, Quy Nhơn",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "nhon.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 2,
            CustomerFullName = "Nguyễn Hồng Thái",
            CustomerUserName = "thai",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-08-19"),
            CustomerEmail = "phamhongthai@gmail.com",
            CustomerAddress = "Tây Ninh",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "thai.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 3,
            CustomerFullName = "Phạm Đức Tài",
            CustomerUserName = "tai",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-08-19"),
            CustomerEmail = "taiphamduc@gmail.com",
            CustomerAddress = "Nam Định",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "tai.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 4,
            CustomerFullName = "dotnet evil",
            CustomerUserName = "nhondeptrai",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-08-28"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "Saigon",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "0d45bade8d1e402fa2615717f3808101.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 16,
            CustomerFullName = "Jeff Bezos",
            CustomerUserName = "acc1",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-08-30"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "America",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "avatar.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 18,
            CustomerFullName = "Bill Gate",
            CustomerUserName = "acc2",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-09-01"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "NewYork",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "avatar.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 19,
            CustomerFullName = "Edward NewGate",
            CustomerUserName = "acc3",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-09-04"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "NewWorld",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "avatar.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 22,
            CustomerFullName = "Monkey D Luffy",
            CustomerUserName = "acc4",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-09-04"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "East Sea",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "avatar.jpg"
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = 23,
            CustomerFullName = "Ái Quyên President",
            CustomerUserName = "acc5",
            CustomerPassword = "Password".Hash(),
            CustomerDateCreated = DateTime.Parse("2022-09-04"),
            CustomerEmail = "vothuongtruongnhon2002@gmail.com",
            CustomerAddress = "Bình Định",
            CustomerPhone = "0905726748",
            CustomerState = true,
            CustomerImage = "avatar.jpg"
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 1,
            BlogName = "Mực rim Quy Nhơn",
            BlogContent = "Mực rim là món ăn phổ biến khiến du thích yêu thích có mặt ở hầu hết những vùng biển lớn. Tuy nhiên mực rim hay còn gọi là mực ngào Bình Định có một hương vị thơm ngon rất riêng từ vùng biển duyên hải miền Trung. Mực rim Quy Nhơn được người dân làm từ những con mực tươi nhất và hương vị không nơi nào giống được. Với hương thơm ngon đặc biệt cùng vị cay cay kích thích vị giác, mực rim trở thành món ăn vặt siêu ngon và được mọi người vô cùng yêu thích. Đồng thời, với những hũ mực rim được làm sẵn giúp bạn có thể dễ dàng lựa chọn đặc sản Bình Định này để làm quà tặng.",
            BlogImage = "mucrim.png",
            BlogDateCreated = DateTime.Parse("2022-08-25")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 2,
            BlogName = "Chả Tré rơm",
            BlogContent = "Với tên gọi độc và lạ của món Chả Tré, món đặc sản Bình Định này đã gợi nên sự tò mò với nhiều du khách muốn tìm hiểu và được thử món ăn độc đáo này. Mặc dù đã có mặt phổ biến khắp các tỉnh thành Trung Trung bộ, nhưng hương vị thơm ngon nhất vẫn là chả Tré Bình Định với cách làm và công thức chỉ vùng đất Bình Định mới làm nên được.Thành phần nguyên liệu làm chả Tré cũng tương tự với các loại nem, bì của miền bắc. Nhưng Tré Bình Định được người dân nơi đây khéo léo thay thế bằng nhiều loại nguyên liệu khác như tai heo, lỗ mũi heo, da heo, thịt ba chỉ,...Tré cũng thích hợp để trở thành món quà mang về khi bạn đến thăm Bình Định.",
            BlogImage = "chatre.png",
            BlogDateCreated = DateTime.Parse("2022-08-25")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 3,
            BlogName = "Chả cá Quy Nhơn",
            BlogContent = "Mặc dù chả cá có thể là đặc sản và có mặt ở nhiều nơi nhưng không phải hương vị chả cá nào cũng như nhau. Sở dĩ chả cá Quy Nhơn là một trong các đặc sản Bình Định nổi tiếng vì vị ngon và lạ đặc trưng. Với nguyên liệu được tuyển chọn từ những con cá biển tươi ngon nhất và công thức chế biến độc quyền của người dân đã tạo nên sự khác biệt cho chả cá Quy Nhơn. Chả cá Quy Nhơn phổ biến có 2 loại là chả hấp và chả chiên. Ngoài việc thưởng thức thực tiếp miếng chả dai, giòn, thơm ngon đặc biệt, các bạn có thể dùng chả cá này để làm “topping” cho các món ăn khác như cơm, bún, phở. Đây cũng là một lựa chọn thích hợp để bạn mua về làm quà cho người thân và bạn bè nữa đó.",
            BlogImage = "chaca.png",
            BlogDateCreated = DateTime.Parse("2022-08-25")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 4,
            BlogName = "Bánh Xèo Mỹ Cang",
            BlogContent = "Đây là một món ngon đặc sản Quy Nhơn rất đỗi bình dị nhưng được du khách rất yêu thích. Nó được bày bán ở hầu hết các quán xá vỉa hè ở Bình Định. Bánh xèo được làm được những  nguyên liệu đơn giản như thịt heo băm nhuyễn, hành phi, rau thơm, trứng và bột gạo. Gaọ sẽ được tuyển chọn những những gạo to chắc mẩy không bị sâu để tạo độ ngọt của bánh. Gạo sẽ được đem đi xay và nấu bột thành một thứ hỗn hợp dẻo, đập trứng cho thịt băm và một số loại gia vị vào. Bên cạnh đó đac có một cái chảo đang được đun nóng. Người nấu sẽ múc từng múc lên chảo để tráng những miếng bánh, dải thịt băm nhuyễn đã được xào chín lên bên trên bề mặt bánh và guộn đều tay để bánh to tròn và đẹp. Hoặc có thể là những con tôm tươi ngon. Khi  ăn ăn kèm với rau thơm và nước chấm.",
            BlogImage = "banh-xeo-my-cang-dac-san-binh-dinh.vntrip-e1501650332846.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 5,
            BlogName = "Bánh tráng nước dừa",
            BlogContent = "Khi đến du lịch Bình Định không thể không nhắc tới  món bánh tráng nước dừa. Đây là một món đặc sản nơi xứ dừa. Công đoạn chế biến bánh không quá cầu kì nhưng đòi hỏi sự tỉ mỉ, có kinh nghiệm của người tráng bánh. Nguyên liệu của bánh chủ yếu là Củ Mì ( củ sắn) được sắt nhỏ, xay lấy nước. Cơm dừa được nạo thành sợi nhỏ,  nước dừa và vừng đen. Tất cả đều được đổ chung vào một nồi lớn, trộn đều cho các gia vị hòa quyện cùng với nhau và được đun nóng. Bên cạnh đó có một chảo đang được đun nóng. Khi chảo nóng lên người tráng bánh sẽ dùng một cái gáo làm bằng sọ dừa có cán dài múc từng gáo nước bánh lên chảo và tráng đều. Tráng bánh phải đều tay để cơm dừa và vừng đen được dàn đều mặt bánh. Bánh phải tròn mỏng và không bị chỗ dày, chỗ mỏng thì mới là bánh đạt chuẩn. cứ tráng được mười chiếc  bánh thì đem ra phơi. khi ăn bạn cần nướng lên để bánh có độ phồng và dậy hết mùi thơm của vừng, của nước cốt dừa và cơm dừa. Có thể ăn bánh thay cơm ăn chỉ thấy no mà không thấy chán.",
            BlogImage = "Banh-trang-nuoc-dua-am-thuc-binh-dinh.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 6,
            BlogName = "Bún song  thần",
            BlogContent = "Bún song thần có chút khác biệt với các loại bún thông thường khác bởi thay vì sợi bún được làm từ bột gạo hay bột củ mì kéo sợi thì bún song thần lại được làm từ bột đậu xanh. Bún Song thần đặc sản Bình Định có màu trắng đặc trưng. Bún được đặt song  song bên nhau nên có tên là bún song thần. Món đặc sản này có giá trị dinh dưỡng cao hơn các loại bún khác. Tuy nhiên giá thành của bún khá cao bởi 5kg đậu xanh chỉ là được 1kg bún.",
            BlogImage = "bat-bun-song-than.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 7,
            BlogName = "Cua Huỳnh Đế",
            BlogContent = "Món món hải sản ngon nức tiếng ở Bình Định. Cua Huỳnh đếđược xem là vua của các loại cua bởi nó có mai đỏ vàng như một bộ long bào uy nghi của các nhà vua, hai bên có gai li ti sắc nhọn, hai chiếc càng to chắc khỏe. Cua thường sống trong những ngách đá trên biển Bình Định. Cua Huỳnh Đế có thịt thơm, chắc  và có thể chế biến thành nhiều món ăn ngon khác nhau như cua nướng, cua hấp… đều rất thơm ngon.",
            BlogImage = "cua-huynh-de-vntrip-e1536313616403.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 8,
            BlogName = "Gỏi cá chích",
            BlogContent = "Cá Chích là loại cá nước ngọt sống ở các sông hồ ao suối. Cũng bởi Bình Định có nhiều sông hồ nên đây là môi trường thuận lợi để loài đặc sản này sinh sống. Cá Chích đặc sản Bình Định có thân  hình nhỏ, dài. Cá Chích sau khi được  đánh bắt lên sẽ được làm  sạch  và chiên giòn. Vì  là loài cá có kích cỡ nhỏ nên  khi ăn  người ta sẽ kẹp cả con cá đã được chiên vàng ăn với bánh phở cuốn, kèm rau thơm, dưa chuột. Cá ngọt thịt nên bạn ăn sẽ không bị chán. Tuy Nhiên nếu bạn là tín đồ gỏi sống bạn có thể được  thưởng thức gỏi cá chích với những thớ thịt  đc lọc xương làm sạch.",
            BlogImage = "goi-ca-chinh-binh-dinh.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 9,
            BlogName = "Bánh hồng Tam Quan",
            BlogContent = "Bánh hồng Tam Quan là một trong những món đặc sản của Bình Định, được xem như biểu trưng cho tin vui, thường xuất hiện trong các dịp cưới hỏi của người dân nơi đây. Điều đặc biệt bánh hồng Tam Quan là bánh được làm từ gạo nếp Ngự nổi tiếng dẻo thơm. Do hoàn toàn không có chất bảo quản nên bánh chỉ để được 5 ngày thôi bạn nhé.",
            BlogImage = "banhhong.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 10,
            BlogName = "Bánh tráng chả cá",
            BlogContent = "Bánh tráng chả cá là một trong những đặc sản nổi tiếng gần xa của Bình Định. Bánh tráng chả cá được làm từ nguyên liệu chính là cá cùng một ít gia vị và bột năng. Để món ăn đúng vị hơn bạn nên ăn kèm với rau răm nhé.",
            BlogImage = "banhtrangchaca.jpg",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            BlogId = 11,
            BlogName = "Mực ngào vị tỏi",
            BlogContent = "Nếu đã đến với đất Bình Định thì bạn nhất định phải thử qua món mực ngào vị tỏi nhé. Món ăn là sự hòa quyện giữa vị mực vừa tươi vừa giòn cùng vị cay đặc trưng của ớt và tỏi. Bạn nhớ bảo quản món này ở nhiệt độ thoáng mát nha.",
            BlogImage = "Mực ngào vị tỏi",
            BlogDateCreated = DateTime.Parse("2022-09-03")
        });

        modelBuilder.Entity<Banner>().HasData(new Banner
        {
            BannerId = 6,
            BannerName = "Chả cá Quy Nhơn",
            ProductDiscount = 0,
            BannerPrice = 100000,
            BannerDescription = "banner1sss",
            BannerImage = "slide_home_1.jpg",
            BannerDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Banner>().HasData(new Banner
        {
            BannerId = 8,
            BannerName = "Gỏi cá Chình",
            ProductDiscount = 0,
            BannerPrice = 200000,
            BannerDescription = "banner2",
            BannerImage = "slide_home_2.jpg",
            BannerDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Banner>().HasData(new Banner
        {
            BannerId = 9,
            BannerName = "Nem chợ huyện",
            ProductDiscount = 0,
            BannerPrice = 150000,
            BannerDescription = "banner3",
            BannerImage = "slide_home_3.jpg",
            BannerDateCreated = DateTime.Parse("2022-08-19")
        });

        modelBuilder.Entity<Banner>().HasData(new Banner
        {
            BannerId = 10,
            BannerName = "Nem chợ huyện",
            ProductDiscount = 0,
            BannerPrice = 150000,
            BannerDescription = "banner4",
            BannerImage = "slide_home_4.jpg",
            BannerDateCreated = DateTime.Parse("2022-08-19")
        });

        // modelBuilder.Entity<Admin>().HasData(new Admin
        // {
        //     AdminId = 1,
        //     AdminUserName = "truongnhon",
        //     AdminPassword = "Password".Hash(),
        //     AdminEmail = "vothuongtruongnhon2002@gmail.com",
        //     AdminImage = "nhon.png",
        //     AdminDateCreated = DateTime.Parse("2022-08-19")
        // });
    }
}
