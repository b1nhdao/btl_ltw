using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BTLLTW_webBanQuanAo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // FOR CATEGORY:
            // 1 --> 3: NAM 
            // 1: Do mac hang ngay (m_casual)
            // 2: Do cong so (m_works)
            // 3: Do the thao (m_sports)
            // Tuong tu: 4 -- > 6: NU (f_casual , f_ ,...)
            // 7: Tre em (kids)


            List<Item> itemList = new List<Item>();
            itemList.Add(new Item(1, "Áo Khoác Gió Thông Minh Nữ Trượt Nước", "resource/aogio_1.jpg", 5, 599000, 539000, "Áo gió thông minh làm từ chất liệu vải gió, được cải tiến và nâng cấp với khả năng trượt nước. Đặc biệt có thể lộn ngược và gấp gọn thành 1 chiếc túi dễ dàng mang đi mọi nơi. Thiết kế gấu áo có chun rút, chun tay tránh gió lùa hiệu quả."));
            itemList.Add(new Item(2, "Áo Khoác Gió Nam Thông Minh Trượt Nước", "resource/aogio_2.jpg", 1, 599000, 539000, "Áo gió thông minh làm từ chất liệu vải gió, được cải tiến và nâng cấp với khả năng trượt nước. Đặc biệt có thể lộn ngược và gấp gọn thành 1 chiếc túi dễ dàng mang đi mọi nơi. Thiết kế gấu áo có chun rút, chun tay tránh gió lùa hiệu quả."));
            itemList.Add(new Item(3, "Áo Khoác Gió Thông Minh Trẻ Em Trượt Nước", "resource/aogiotreem_3.png", 9, 0, 499000, "Áo gió thông minh làm từ chất liệu vải gió, được cải tiến và nâng cấp với khả năng trượt nước. Đặc biệt có thể lộn ngược và gấp gọn thành 1 chiếc túi dễ dàng mang đi mọi nơi. Thiết kế gấu áo có chun rút, chun tay tránh gió lùa hiệu quả."));
            itemList.Add(new Item(4, "Áo Khoác Gió Thể Thao Nam Một Lớp Phối Khóa", "resource/aokhoacthethao_1.png", 3, 599000, 539000, "Áo gió thông minh làm từ chất liệu vải gió, được cải tiến và nâng cấp với khả năng trượt nước. Đặc biệt có thể lộn ngược và gấp gọn thành 1 chiếc túi dễ dàng mang đi mọi nơi. Thiết kế gấu áo có chun rút, chun tay tránh gió lùa hiệu quả."));
            
            itemList.Add(new Item(5, "Aó thu đông Nam giữ nhiệt cổ 3cm", "resource/male_casual/Áo Thun Đông Nam Giữ Nhiệt Cổ 3cm-ATM7011-TRA (2).jpg", 1, 299000, 239000, "Được biết đến là sáng tạo tuyệt vời của ngành dệt may - sợi tái sinh có nguồn gốc từ Bamboo/ Tre ngày càng trở nên phổ biến. Chiếc áo này, với sự kết hợp của Bamboo và Spandex giúp vải sở hữu các tính năng ưu việt như mềm mại, thoáng, thấm hút tốt, co giãn hiệu quả, độ bền cao."));
            itemList.Add(new Item(6, "Aó thu đông Nam giữ nhiệt cổ tròn", "resource/male_casual/ao-thu-dong-nam-giu-nhiet-co-tron-yody-ATM7004-GHI (5).jpg", 1, 0, 179000, "Giữ nhiệt tốt, ấm áp từ trong ra ngoài cùng áo thun giữ nhiệt YODY. Chiếc áo này siêu thích hợp để mặc trong những ngày trời trở lạnh. Chất liệu Bamboo mềm mại, thoáng, co giãn tốt lại thân thiện với da. Sở hữu ngay nhé!"));
            itemList.Add(new Item(7, "Áo thun nam clean Việt Nam", "resource/male_casual/ao-thun-nam-clean-yody-tsm7137-ghi-1.jpg", 1, 0, 299000, "Áo phông nam Clean Vietnam sử dụng chất liệu sợi lành tính, an toàn và thân thiện với người dùng cho cảm giác mặc mềm mại, thông thoáng. Thiết kế tối giản với dòng chữ in nổi phía sau lưng truyền tải thông điệp bảo vệ môi trường một cách ngắn gọn."));
            itemList.Add(new Item(8, "Áo Tshirt Yoguu Living Legend", "resource/male_casual/gut7020-xdd-3.jpg", 1, 349000, 174500, "Nằm trong dòng sản phẩm mới nhất YOGUU, là sự kết hợp của YOung - Gout - Unisex - Unique. Điểm nhấn là hình in Living Legend nổi bật cá tính. Thiết kế dáng cơ bản dễ mặc, dễ phối, màu sắc đa dạng. Thích hợp với cả nam và nữ đều có thể sử dụng. Size 1: Nam dưới 65kg, Nữ dưới 60kg. Size 2: Nam dưới 80kg, Nữ trên 60kg"));
            itemList.Add(new Item(9, "Quần Short Jeans nam ", "resource/male_casual/quan-short-jeans-nam-yody-SJM7038-XDM (1).jpg", 1, 0, 339000, "Chất liệu cotton mềm mại kết hợp Rayon hạn chế khô cứng sau khi giặt, co giãn nhẹ nhàng nhờ Spandex. Quần short sử dụng REPREVE® - sợi tái chế từ chai nhựa, giảm thiểu tác động môi trường. Sản phẩm thông thoáng, thấm hút mồ hôi tốt cho bạn cảm giác thoải mái suốt ngày dài.\r\n"));
            itemList.Add(new Item(10, "Quần Short Nam Đen", "resource/male_casual/quan-short-jeans-nam-sjm6003-den-2-yody.jpg", 1, 0, 299000, "Chất liệu cotton mềm mại kết hợp Rayon hạn chế khô cứng sau khi giặt, co giãn nhẹ nhàng nhờ Spandex. Quần short sử dụng REPREVE® - sợi tái chế từ chai nhựa, giảm thiểu tác động môi trường. Sản phẩm thông thoáng, thấm hút mồ hôi tốt cho bạn cảm giác thoải mái suốt ngày dài.\r\n"));
            itemList.Add(new Item(11, "Quần Short Nam Yoogu", "resource/male_casual/quan-short-nam-yoguu-gus7004-den-1.jpg", 1, 0, 299000, "Chất liệu cotton mềm mại kết hợp Rayon hạn chế khô cứng sau khi giặt, co giãn nhẹ nhàng nhờ Spandex. Quần short sử dụng REPREVE® - sợi tái chế từ chai nhựa, giảm thiểu tác động môi trường. Sản phẩm thông thoáng, thấm hút mồ hôi tốt cho bạn cảm giác thoải mái suốt ngày dài.\r\n"));

            itemList.Add(new Item(12, "Aó sơ mi nam cộc tay Cafe", "resource/male_work/ao-so-mi-nam-coc-tay-yody-scm7037-ghi-14.jpg", 2, 0, 529000, "Vải cafe sản xuất tiết kiệm năng lượng, sử dụng những giá trị bền vững và thân thiện với mội trường. Siêu nhẹ, siêu mát, kiểm soát mùi cơ thể và chống tia UV. Thoáng khí, nhanh khô tạo cảm giác dễ chịu cho người mặc."));
            itemList.Add(new Item(13, "Aó sơ mi nam dài tay 1", "resource/male_work/smm5207-den-6.jpg", 2, 600000, 569000, "Thiết kế dài tay cơ bản, phom dáng suông khỏe khoắn tôn lên vóc dáng nam tính. Điểm nhấn chữ nổi EVERYDAY trên ngực áo tạo phong cách trẻ trung, năng động. Dễ dàng phối với quần âu, quần kaki dài hoặc quần short cho nhiều dịp khác nhau.\r\n"));
            itemList.Add(new Item(14, "Aó sơ mi nam dài tay 2", "resource/male_work/ao-so-mi-nam-dai-tay-yody-smm6133-kxe-2.jpg", 2, 0, 529000, "Thiết kế dài tay cơ bản, phom dáng suông khỏe khoắn tôn lên vóc dáng nam tính. Điểm nhấn chữ nổi EVERYDAY trên ngực áo tạo phong cách trẻ trung, năng động. Dễ dàng phối với quần âu, quần kaki dài hoặc quần short cho nhiều dịp khác nhau.\r\n"));
            itemList.Add(new Item(15, "Sơ Mi Sợi Tre Dài Tay Quốc Dân", "resource/male_work/ao-so-mi-nam-SMM7007-TRA (1).jpg", 2, 0, 399000, "Thoáng mát có tính hút ẩm rất cao, thấm hút mồ hôi tốt hơn rất nhiều so với sợi vải cotton. Chống lại tia cực tím hay tia UV cực kỳ cao, cực kỳ hiểu hiệu quả. Thiết kế lịch lãm, kẻ caro tỉ mỉ tạo nên phối đồ lịch sự.\r\n"));
            itemList.Add(new Item(16, "Sơ Mi Dài Tay Nam Ly Chiết", "resource/male_work/ao-so-mi-nam-dai-tay-yody-smm6095-xlo-11.jpg", 2, 0, 529000, "Áo sơ mi nam được dệt từ sợi vải Bamboo tạo nên cấu trúc sợi vải bền vững. Áo có khả năng điều hòa thân nhiệt, chống nhăn tự nhiên nhờ chất vải mang đặc tính mát mẻ khi chạm vào. Form dáng quen thuộc, đường may tỉ mỉ, dễ mặc, dễ phối đồ."));
            itemList.Add(new Item(17, "Quần Âu Nam Classic Phối Lé", "resource/male_work/qam6075-xde-smm6087-xnh-3.jpg", 2, 0, 499000, "Lựa chọn hoàn hảo vừa lịch lãm, vừa thoải mái cho công việc, đi chơi hay sự kiện. Sợi vải có rãnh giúp tăng khả năng thoát nhiệt, mang lại cảm giác mát mẻ. Bề mặt bóng mượt: do bề mặt sợi bóng mượt hơn sợi tự nhiên"));
            itemList.Add(new Item(18, "Quần Âu Nam Cạp Di Động", "resource/male_work/quan-au-nam-QAM7015-DN1 (1).jpg", 2, 0, 499000, "Những chiếc quần âu không cần cầu kỳ nhưng lại giúp nam giới thể hiện được phong thái mỗi khi xuất hiện. Sở hữu 1 chiếc quần âu Nano thoải mái, lịch lãm, bền đẹp sẽ giúp bạn nâng tầm phong cách mà không cần quá nhiều phụ kiện."));

            //new
            itemList.Add(new Item(19, "Áo thun Thể Thao Nam", "resource/male_sports/ao-thun-the-thao-nam-stm7073-den-1.jpg", 3, 0, 349000, "Công nghệ dệt Jacquard hiện đại, tạo họa tiết lỗ độc đáo. Thấm hút tốt, khô nhanh, thông thoáng nhờ kiểu dệt - tạo cảm thoải mái cho làn da. Kiểu dáng áo thun thể thao basic, trẻ trung, năng động. Cổ tròn, ôm sát cổ, tạo cảm giác thoải mái khi vận động.\r\n"));
            itemList.Add(new Item(20, "Áo Polo Thể Thao Nam Airy Cool Phối Bo", "resource/male_sports/Ao-polo-the-thao-nam.jpg", 3, 0, 379000, "Thuộc dòng YODY SPORT thế hệ mới. Thiết kế dáng suông phối bo thoải mái, năng động và hiện đại. Công nghệ làm mát FREEZING tiên tiến siêu khô thoáng, với cơ chế làm mát tự nhiên giúp cho người mặc cảm giác thoải mái trong mọi hoạt động.\r\n"));
            itemList.Add(new Item(21, "Quần Sooc Thể Thao Nam In Sau", "resource/male_sports/quan-short-nam-sqm6025-xcv-8.jpg", 3, 399000, 199500, "Quần short gió thu hút với kiểu dệt Knitting hiện đại cho dòng sản phẩm sport thế hệ mới. Co giãn và thấm hút tốt tạo cảm giác thoải mái cho người sử dụng. Thiết kế ngang gối, có dây rút, cạp chun to chắc chắn, khoá túi tiện lợi.\r\n"));
            itemList.Add(new Item(22, "Quần Gió Thể Thao Nam 4 Mùa", "resource/male_sports/quan-gio-nam-the-thao-yody-sgm6021-ghd-stm6087-tit-6-2.jpg", 3, 0, 469000, "Chiếc quần chạy bộ trọng lượng nhẹ này sẽ giúp bạn có trải nghiệm tuyệt vời khi tham gia các hoạt động tập luyện thể thao mỗi ngày. Thiết kế chú trọng vào sự thoải mái, kiểu dáng vừa vặn giúp cơ mông và đùi có không gian thở. Trang bị ngay sản phẩm này nhé!\r\n"));
            itemList.Add(new Item(23, "Áo thun Thể Thao Nam", "resource/male_sports/Bo-Do-the-thao-nam-in-super-sport.jpg", 3, 0, 949000, "Mẫu áo khoác chất liệu nhẹ, mỏng, tạo cảm giác thoải mái khi mặc. Chống thấm nước tốt, giúp bạn luôn khô ráo trong những cơn mưa bất chợt. Chống tia UV UPF50+, bảo vệ da khỏi tác hại của ánh nắng mặt trời. Khô nhanh, hạn chế vi khuẩn phát triển."));
            itemList.Add(new Item(24, "Áo Khoác Gió Thể Thao Nam Một Lớp Phối Khóa", "resource/male_sports/ao-khoac-gio-nam-the-thao-yody-SKM7005-DEN-5.jpg", 3, 599000, 500000, "Mẫu áo khoác chất liệu nhẹ, mỏng, tạo cảm giác thoải mái khi mặc. Chống thấm nước tốt, giúp bạn luôn khô ráo trong những cơn mưa bất chợt. Chống tia UV UPF50+, bảo vệ da khỏi tác hại của ánh nắng mặt trời. Khô nhanh, hạn chế vi khuẩn phát triển."));

            itemList.Add(new Item(25, "T-shirt Nữ Dáng Rộng In Cô Gái Chất Liệu Cotton Usa", "resource/female_casual/ao-thun-nu-tsn6088-tr1-7.jpg", 4, 0, 99000, "Áo thun dáng rộng thoải mái. Điểm nhấn là hình in mảng lớn nổi bật với cô gái trẻ cá tính và trẻ trung. Được làm từ những sợi bông tốt nhất thế giới, chiếc áo mang đến sự dễ chịu hoàn hảo khi mặc.\r\n"));
            itemList.Add(new Item(26, "Áo Thu Đông Nữ Mickey And Friend", "resource/female_casual/ao-thu-dong-nu-mickey-and-friend-yody-atn6136-ddo-6.jpg", 4, 0, 499000, "Nằm trong BST Mickey nổi bật mùa thu đông 2023, sản phẩm vừa ấm áp vừa xinh xắn dành cho các chị em. Chất nỉ dày dặn giữ ấm tốt. Hình in hiện đại tạo điểm nhấn thú vị ở mặt sau lưng áo.\r\n"));
            itemList.Add(new Item(27, "Áo Thu Đông Nữ Dáng Ôm Khuyên Cổ", "resource/female_casual/ao-thun-thu-dong-dai-tay-yody-atn6024-xla-cvn6064-kem-3.jpg", 4,0, 249000, "Dáng skinny ôm sát cơ thể tôn trọn vòng 3 và đôi chân cực đẹp. Chất liệu co giãn 4 chiều thoải mái, mềm mịn, dễ chịu. Thích hợp phối với áo T-shirt, Polo, Sơ mi hay Tank-top mặc được cả mùa đông và mùa hè.\r\n"));
            itemList.Add(new Item(28, "Quần Jeans Nữ Skinny Lưng Cao Hack Dáng", "resource/female_casual/quan-jean-nu-5068-xah-7.jpg", 4, 0, 149000, "Dáng skinny ôm sát cơ thể tôn trọn vòng 3 và đôi chân cực đẹp. Chất liệu co giãn 4 chiều thoải mái, mềm mịn, dễ chịu. Thích hợp phối với áo T-shirt, Polo, Sơ mi hay Tank-top mặc được cả mùa đông và mùa hè.\r\n"));
            itemList.Add(new Item(29, "Quần Đùi Nữ Thể Thao Basic", "resource/female_casual/quan-the-thao-ssn7046-ghi-2.jpg", 4, 349000, 175500, "Thiết kế cạp di động tiện lợi, dễ dàng điều chỉnh theo số đo vòng eo, phù hợp với mọi vóc dáng. Kiểu dáng thanh lịch, hiện đại, thích hợp cho cả công sở và dạo phố. Co giãn tuyệt vời mang đến cảm giác thoải mái, mát mẻ trong mọi hoạt động."));
            itemList.Add(new Item(30, "Váy Thun Nữ Dáng Rộng Phố Tay Madrid", "resource/female_casual/vtn6014-dtv-6-75da344e-8e41-48db-9062-17bd7af4bbd1.jpg", 4, 0, 99000, "Sợi compact có độ bền gấp 3 lần cotton thường. Thấm hút mồ hôi cực tốt, thoáng mát thích hợp với thời tiết nóng ẩm của Việt Nam. Co giãn tốt, thích hợp với chuyển động của cơ thể khi hoạt động. Hình in ở ngực áo MADRID năng động, cá tính.\r\n"));

            itemList.Add(new Item(31, "Áo Sơ Mi Tay Dài Nữ Cổ Đức Tay Phối Voan", "resource/female_work/ao-so-mi-nu-SMN7124-BEE (1).jpg", 5, 0, 399000, "Cảm giác chạm tay mềm mịn mang lại sự thoải mái khi mặc. Co giãn nhẹ giúp vận động dễ dàng. Thiết kế cổ đức thanh lịch, tay phối voan nhẹ nhàng. Dễ dàng phối đồ, phù hợp cho nhiều dịp khác nhau cho cả đi làm, đi chơi hay dự tiệc.\r\n"));
            itemList.Add(new Item(32, "Áo Sơ Mi Tay Ngắn Nữ Tay Phối Tơ Bồng", "resource/female_work/ao-so-mi-nu-tay-ngan.jpg", 5, 0, 499000, "Cảm giác chạm tay mềm mịn mang lại sự thoải mái khi mặc. Co giãn nhẹ giúp vận động dễ dàng. Thiết kế cổ đức thanh lịch, tay phối voan nhẹ nhàng. Dễ dàng phối đồ, phù hợp cho nhiều dịp khác nhau cho cả đi làm, đi chơi hay dự tiệc.\r\n"));
            itemList.Add(new Item(33, "Áo Sơ Mi Tay Dài Nữ Cổ Bèo Dáng Suông", "resource/female_work/ao-so-mi-tay-dai-nu-co-beo-dang-suong-smn6078-cam-5.jpg", 5, 500000, 399000, "Cảm giác chạm tay mềm mịn mang lại sự thoải mái khi mặc. Co giãn nhẹ giúp vận động dễ dàng. Thiết kế cổ đức thanh lịch, tay phối voan nhẹ nhàng. Dễ dàng phối đồ, phù hợp cho nhiều dịp khác nhau cho cả đi làm, đi chơi hay dự tiệc.\r\n"));
            itemList.Add(new Item(34, "Quần Âu Nữ Suông Siêu Co Giãn", "resource/female_work/quan-au-nu-qan7024-den-5.jpg", 5, 0, 399000, "Chiếc quần mang đến trải nghiệm của sự thoải mái và phong cách. Thiết kế ống suông rộng rãi, thanh lịch, dễ dàng phối hợp với nhiều kiểu áo khác nhau. Sản phẩm mặc thoải mái phù hợp cho cả đi làm công sở và dạo phố.\r\n"));
            itemList.Add(new Item(35, "Quần Âu Nữ Dáng Baggy Cúc Trang Trí Mí Gân", "resource/female_work/qan6170-nad-12-5.jpg", 5, 399000, 199500, "Chiếc quần mang đến trải nghiệm của sự thoải mái và phong cách. Thiết kế ống suông rộng rãi, thanh lịch, dễ dàng phối hợp với nhiều kiểu áo khác nhau. Sản phẩm mặc thoải mái phù hợp cho cả đi làm công sở và dạo phố.\r\n"));
            itemList.Add(new Item(36, "Chân Váy Nữ Dập Ly Xoè Cơ Bản", "resource/female_work/chan-vay-nu-yody-cvn7052-ghs-1.jpg", 5, 440000, 224500, "Chân váy xếp ly là một món đồ không thể thiếu trong tủ đồ nữ tính cho các nàng. Thiết kế đơn giản, dễ mặc, dễ phối chắc chắn sẽ giúp nàng thoả sức sáng tạo những outfits năng động mà cũng vô cùng chỉn chu mỗi ngày.\r\n"));
            itemList.Add(new Item(37, "Váy Nữ Tay Bồng", "resource/female_work/van6170-den-2.jpg", 5, 0, 149000, "Thoải mái vải co giãn, không nhăn, nhanh khô. Họa tiết hoa nổi phối tơ giúp thiết kế nữ tính. Phần tay bồng giúp che đi khuyết điểm bắp tay. Điểm nhấn là 1 chiếc cúc đá hoa đính trên cổ áo giúp chiếc đầm trở nên tinh tế và cuôn hút hơn.\r\n"));

            itemList.Add(new Item(38, "Bộ Đồ Thể Thao Nữ Nỉ Có Mũ In Logo", "resource/female_sports/do-bo-nu-sdn6036-csh-4.jpg", 6, 0, 849000, "Bộ đồ nỉ thể thao đôi nam nữ với áo khoác có mũ, dây rút và chốt điều chỉnh độ rộng chật của mũ khi mặc. Hình in kẻ chéo khỏe khoắn tại vị trí thân trước áo chất liệu in cao su bền đẹp. Áo và quần đều có túi khóa tiện dụng khi sử dụng\r\n"));
            itemList.Add(new Item(39, "Áo Polo Thể Thao Nữ Airycool Phối Nẹp", "resource/female_sports/ao-polo-the-thao-nu-san5028-xlo-1.jpg", 6, 0, 329000, "Sản phẩm nằm trong BST YODY Sport - Áo Polo thể thao mới. Công nghệ làm mát FREEZING tiên tiến giúp giải nhiệt cơ thể cho ngày hè mát mẻ. Mềm mịn, thoáng thoáng, hút ẩm tốt. Thoải mái tham gia các vận động cường độ cao"));
            itemList.Add(new Item(40, "T-shirt Nữ Yody Sport", "resource/female_sports/t-shirt-nu-sport.jpg", 6, 0, 299000, "Sản phẩm nằm trong BST YODY Sport - Áo Polo thể thao mới. Công nghệ làm mát FREEZING tiên tiến giúp giải nhiệt cơ thể cho ngày hè mát mẻ. Mềm mịn, thoáng thoáng, hút ẩm tốt. Thoải mái tham gia các vận động cường độ cao"));
            itemList.Add(new Item(41, "Quần Thể Thao Nữ Túi Cạp", "resource/female_sports/quan-short-the-thao-nu-yody-ssn7018-ghi-13.jpg", 6, 349000, 174500, "Quần short nữ thể thao mang lại cho phái đẹp vẻ ngoài năng động, khoẻ khoắn. Thiết kế quần thể thao 2 lớp cho nàng yên tâm sử dụng, co giãn tuyệt vời, phù hợp với các hoạt động thể chất năng động.\r\n"));
            itemList.Add(new Item(42, "Quần Thể Thao Nữ Túi Cạp Sau", "resource/female_sports/quan-the-thao-nu-yody-sgn6002-gre-5.jpg", 6, 0, 549000, "Quần short nữ thể thao mang lại cho phái đẹp vẻ ngoài năng động, khoẻ khoắn. Thiết kế quần thể thao 2 lớp cho nàng yên tâm sử dụng, co giãn tuyệt vời, phù hợp với các hoạt động thể chất năng động.\r\n"));
            itemList.Add(new Item(43, "Áo Khoác Thể Thao Nữ Siêu Nhẹ", "resource/female_sports/ao-khoac-nu-SKN7004-HOG (1).jpg", 6, 0, 399000, "Chất liệu Nylon 100% bền bỉ, siêu nhẹ. Thoáng mát tối ưu với khả năng thoát mồ hôi nhanh, giúp bạn luôn khô ráo. Thiết kế gọn nhẹ dễ dàng cất giữ trong balo, túi xách, tiện lợi cho mọi chuyến đi. Bạn đồng hành hoàn hảo cho tập luyện thể thao, đi dã ngoại, du lịch hay những hoạt động ngoài trời.\r\n"));

            itemList.Add(new Item(44, "Đồ Bộ Kid Phối Kẻ In Xe", "resource/kids/bo-do-tre-em-bdk6084-tla-2.jpg", 7, 299000, 149500, "Thiết kế basic dễ mặc, họa tiết quần kẻ áo in xe ngộ nghĩnh. Quần áo nhanh khô, form chuẩn, dễ dàng về form sau khi giặt. Phù hợp cho bé mặc hàng ngày, nhất là trong mùa hè nóng bức.\r\n"));
            itemList.Add(new Item(45, "Bộ Đồ Trẻ Em In Faster", "resource/kids/bo-do-tre-em-bdk7126-tbl-1.jpg", 7, 0, 269000, "Thiết kế basic dễ mặc, họa tiết quần kẻ áo in xe ngộ nghĩnh. Quần áo nhanh khô, form chuẩn, dễ dàng về form sau khi giặt. Phù hợp cho bé mặc hàng ngày, nhất là trong mùa hè nóng bức.\r\n"));
            itemList.Add(new Item(46, "Bộ Đồ Thu Đông Kid Tennis", "resource/kids/bo-do-tre-em-btk6084-den-1.jpg", 7, 0, 499000, "Bộ đồ co giãn nhẹ, thoải mái cho hoạt động cơ thể. Thiết kế thu đông dài tay với điểm nhấn là hình in tennis trước ngực. Chất liệu da cá dày dặn với vết cấu sợi tạo nên mặt vải đanh chắc giúp giữ ấm tốt cho bé khi mặc.\r\n"));
            itemList.Add(new Item(47, "Áo Dài Tay Kid Tomorrow", "resource/kids/ao-thun-tre-em-atk7024-vag-1.jpg", 7, 0, 149000, "Chất liệu nỉ ép thấm hút tốt, co giãn tốt. Kết cấu sợi tạo nên mặt vải đanh chắc, không bị bai dão, ít xù. Mặt vải tạo nên sự ấm áp cho khi mặc, độ bền cao. Áo có form dáng rộng tạo sự thoải mái. Thiết kế tạo điểm nhấn với phần chữ TOMORROW thêu trước ngực.\r\n"));
            itemList.Add(new Item(48, "Quần Dài Kid Nhỏ Khóa Gối", "resource/kids/qnk6052-den-8.jpg", 7, 0, 269000, "Quần nỉ hai mặt mềm mại, thoải mái. Thấm hút tốt, kiểm soát độ ẩm. Khô nhanh. Quần bo gấu, với điểm nhấn là đường súp được in chữ và lé phối ngang gối tạo sự phá cách tinh nghịch khoẻ khoắn cho bé.\r\n"));
            itemList.Add(new Item(49, "Đầm bé gái gấu nhún chấm bi", "resource/kids/vnk5292-tim01.jpg", 7, 0, 99000, "Váy nỉ da cá mềm mại, ấm áp mặc được cả trong màu thu đông. Dáng chữ A, họa tiết chấm bi cùng gấu váy nhún bèo tạo nét đáng yêu, dễ thương cho các bé. Thích hợp phối cùng quần tất mặc ở nhà hoặc đi chơi đều đẹp.\r\n"));
            itemList.Add(new Item(50, "T-shirt Kid You Are Loved", "resource/kids/ao-thun-tre-em-TSK7247-DEN (1).jpg", 7, 0, 149000, "Áo phông bé yêu \"You Are Loved\" Cotton 95/5 cao cấp, mềm mịn, co giãn tốt thoải mái vận động. Chất liệu tự nhiên, thấm hút mồ hôi nhanh chóng giữ cho bé luôn khô thoáng. Sản phẩm thân thiện với môi trường và an toàn cho sức khỏe của bé.\r\n"));
            itemList.Add(new Item(51, "Quần Short Bé Trai Khoá Ngang Gố", "resource/kids/qsk7008-den-apk5019-xd1-3-2.jpg", 7, 220000, 114500, "Chất liệu nhẹ, mềm mại, tạo cảm giác thoải mái khi mặc.Thấm hút mồ hôi tốt, giúp bé luôn khô ráo và thoáng mát khi vận động. Khô nhanh, hạn chế vi khuẩn phát triển. Độ co giãn tốt, giúp bé dễ dàng vận động.Khóa ngang gối tạo điểm nhấn mới lạ, độc đáo.\r\n"));

            Application["itemList"] = itemList;

            // object: List<Item> 
            //Application["itemList"] : 51 items. Count();


            List<ItemCart> itemCarts = new List<ItemCart>();
            Application["itemCart"] = itemCarts;



            List<User> users = new List<User>();
            users.Add(new User(1, "admin", "admin123", "admin", "A", "A", "A"));
            users.Add(new User(2, "shaoang", "dasdas", "admin", "A", "A" , "A"));
            Application["Users"] = users;

            Application["nextUserId"] = 3;
            Application["itemCount"] = itemList.Count;

        }
    }
}