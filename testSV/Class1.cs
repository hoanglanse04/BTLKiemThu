using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using duancankiemthu;
using NUnit.Framework.Legacy;
using static duancankiemthu.Program;

namespace testSV
{
    [TestFitxure]
    public class Class1
    {

        [Test]
        public void Test_DuLieuHopLe()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void Test_MaSinhVienTrong()
        {
            // Arrange
            string maSV = "";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_MaSinhVienKhac10KyTu()
        {
            // Arrange
            string maSV = "2251171";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_MaSinhVienChuaKiTuDacBiet()
        {
            // Arrange
            string maSV = "225117142@";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_MaSinhVienChuaChuCai()
        {
            // Arrange
            string maSV = "225117123a";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_KhoaNhapHocKhongHopLe()
        {
            // Arrange
            string maSV = "9991171234";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_MaNganhKhongHopLe()
        {
            // Arrange
            string maSV = "2259991234";
            string hoTen = "Nguyễn Văn A";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Test_HoTenSinhVienTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsTrue(result);
        }
        [Test]
        public void Test_HotenSinhVienDaihon40KyTu()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana Nguyenvana Nguyenvana Nguyenvana Nguyenvana Nguyenvana Nguyenvana NguyenvanaNguyenvanaNguyenvanaNguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_HoTenSinhVienChuaKhoangTrangLienTiep()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana   abc";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_HotenSinhVienChuaKiTuDacBiet()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana@";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_NgaySinhDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_NgaySinhKhongDungDinhDang()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "2024/12/10";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_NgaySinhNhoHon17Tuoi()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2020";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_DiaChiSinHVienDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_DiaChiSinhVienChuaKhoangTrangLienTiep()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "hà    nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_DiaChiSinhVienChuaKyTuDacBiet()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội @";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_DiaChiSInhVienQuaDai()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "NguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvana";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTChuaKhoangTrang()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "01234  56789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTChuaKyTuDacBiet()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "01234567@9";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTChuachuCai()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "012345678a";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTKhongBatDauBang0()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "1423456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_SDTKhac10KyTu()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "09876543222";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_EmaiLDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_EmailKhongDungDinhDang()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "--123@gmail...com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_EmailQuaDai()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "abcNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvanaNguyenvana@gmail.com";
            bool rdoNam = true;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_GioiTinhDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = false;
            string maLopHanhChinh = "59KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_MaLopHanhChinhDeTrong()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_MaLopHanhChinhChuaKytuDacBiet()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = false;
            string maLopHanhChinh = "59KTPM1@";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_MaLophanhChinhDaiHon10KyTu()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = false;
            string maLopHanhChinh = "59KTPM11234544";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }
        [Test]
        public void Test_MaLopHanhChinhKhongHopLe()
        {
            // Arrange
            string maSV = "2251171234";
            string hoTen = "Nguyenvana";
            string ngaySinh = "15/08/2004";
            string diaChi = "Hà Nội";
            string soDt = "0123456789";
            string email = "email@example.com";
            bool rdoNam = true;
            string maLopHanhChinh = "99KTPM1";

            // Act
            bool result = Program.KiemTraDuLieu(maSV, hoTen, ngaySinh, diaChi, soDt, email, rdoNam, maLopHanhChinh);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void TestValidMaSV()
        {
            string result = Program.KiemTraTimKiem("2251171234", "", "", "");
            ClassicAssert.AreEqual("Hiển thị thông tin sinh viên có mã sinh viên tương ứng", result);
        }

        [Test]
        public void TestValidHoTen()
        {
            string result = Program.KiemTraTimKiem("", "Nguyen Van A", "", "");
            ClassicAssert.AreEqual("Hiển thị danh sách sinh viên có tên trùng khớp", result);
        }

        [Test]
        public void TestValidMaLop()
        {
            string result = Program.KiemTraTimKiem("", "", "KTPM1", "");
            ClassicAssert.AreEqual("Hiển thị danh sách sinh viên thuộc mã lớp hành chính tương ứng", result);
        }

        [Test]
        public void TestValidKhoa()
        {
            string result = Program.KiemTraTimKiem("", "", "", "CNTT");
            ClassicAssert.AreEqual("Hiển thị danh sách sinh viên thuộc khoa tương ứng", result);
        }

        [Test]
        public void TestAllValidInputs()
        {
            string result = Program.KiemTraTimKiem("2251171234", "Nguyen Van A", "KTPM1", "CNTT");
            ClassicAssert.AreEqual("Hiển thị thông tin sinh viên phù hợp với cả 4 tiêu chí", result);
        }

        [Test]
        public void TestInvalidMaSV()
        {
            string result = Program.KiemTraTimKiem("123", "", "", "");
            ClassicAssert.AreEqual("Không tìm thấy sinh viên", result);
        }

        [Test]
        public void TestInvalidHoTen()
        {
            string result = Program.KiemTraTimKiem("", "A", "", "");
            ClassicAssert.AreEqual("Không tìm thấy sinh viên", result);
        }

        [Test]
        public void TestInvalidData()
        {
            string result = Program.KiemTraTimKiem("", "", "", "");
            ClassicAssert.AreEqual("Dữ liệu không hợp lệ", result);
        }

        [Test]
        public void TestXoavalid()
        {
            bool result = Program.KiemTraXoa("1");
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void TestXoaInvalid()
        {
            bool result = Program.KiemTraXoa("2");
            ClassicAssert.IsFalse(result);
        }

    }



}
