using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duancankiemthu
{
    public class Program
    {
        public static void Main()
        {
            // Thay thế các biến textbox bằng các biến thông thường
            string tbMaSV = "2251171234";  // Ví dụ mã sinh viên
            string tbHoTen = "Nguyễn Văn A"; // Ví dụ họ tên
            string tbNgaysinh = "15/08/2005"; // Ví dụ ngày sinh
            string tbDiaChi = "Hà Nội"; // Ví dụ địa chỉ
            string tbSoDt = "0123456789"; // Ví dụ số điện thoại
            string tbEmail = "email@example.com"; // Ví dụ email
            bool rdoNam = true; // Giới tính nam
            string maLopHanhChinh = "59KTPM1"; // Mã lớp hành chính

            bool isValid = KiemTraDuLieu(tbMaSV, tbHoTen, tbNgaysinh, tbDiaChi, tbSoDt, tbEmail, rdoNam, maLopHanhChinh);
            Console.WriteLine("Dữ liệu " + (isValid ? "hợp lệ" : "không hợp lệ"));
            Console.ReadLine();
        }

        public static bool KiemTraDuLieu(string tbMaSV, string tbHoTen, string tbNgaysinh, string tbDiaChi, string tbSoDt, string tbEmail, bool rdoNam, string maLopHanhChinh)
        {
            // Mảng chứa khóa nhập học và mã ngành hợp lệ
            string[] khoaNhapHoc = { "225", "215", "235", "245", "205" };
            string[] maNganh = { "117", "116", "115", "114", "113", "112", "111", "110", "241", "242", "234", "125", "127", "129", "102", "103", "104" };

            // Kiểm tra Mã sinh viên
            if (string.IsNullOrWhiteSpace(tbMaSV))
            {
                Console.WriteLine("Mã sinh viên không được để trống!");
                return false;
            }
            if (tbMaSV.Length != 10)
            {
                Console.WriteLine("Mã sinh viên phải có đúng 10 ký tự!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbMaSV, @"[^a-zA-Z0-9]"))
            {
                Console.WriteLine("Mã sinh viên không được chứa ký tự đặc biệt!");
                return false;
            }
            if (tbMaSV.Contains(" "))
            {
                Console.WriteLine("Mã sinh viên không được chứa khoảng trống!");
                return false;
            }

            string maSinhVien = tbMaSV.Trim();
            string khoaNhap = maSinhVien.Substring(0, 3); // 3 ký tự đầu (khóa nhập học)
            string maNganhSinhVien = maSinhVien.Substring(3, 3); // 3 ký tự tiếp theo (mã ngành)

            if (!khoaNhapHoc.Contains(khoaNhap))
            {
                Console.WriteLine("Khóa nhập học không hợp lệ!");
                return false;
            }
            if (!maNganh.Contains(maNganhSinhVien))
            {
                Console.WriteLine("Mã ngành không hợp lệ!");
                return false;
            }

            // Kiểm tra Tên sinh viên
            if (string.IsNullOrWhiteSpace(tbHoTen))
            {
                Console.WriteLine("Họ tên sinh viên không được để trống!");
                return false;
            }
            if (tbHoTen.Length > 40)
            {
                Console.WriteLine("Họ tên sinh viên không được dài hơn 40 ký tự!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbHoTen, @"\s{2,}"))
            {
                Console.WriteLine("Họ tên sinh viên không được chứa khoảng trắng liên tiếp!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbHoTen, @"[^a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễỆỉỊọỏốồổỗộớờởỡợụủứừửữự\s]"))
            {
                Console.WriteLine("Họ tên sinh viên không được chứa ký tự đặc biệt!");
                return false;
            }

            // Kiểm tra Ngày sinh
            if (string.IsNullOrWhiteSpace(tbNgaysinh))
            {
                Console.WriteLine("Ngày sinh không được để trống!");
                return false;
            }
            DateTime ngaySinh;
            if (!DateTime.TryParseExact(tbNgaysinh.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                Console.WriteLine("Ngày sinh không đúng định dạng dd/MM/yyyy!");
                return false;
            }

            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;
            if (tuoi < 17)
            {
                Console.WriteLine("Sinh viên phải từ 17 tuổi trở lên!");
                return false;
            }

            // Kiểm tra Địa chỉ
            if (string.IsNullOrWhiteSpace(tbDiaChi))
            {
                Console.WriteLine("Địa chỉ sinh viên không được để trống!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbDiaChi, @"\s{2,}"))
            {
                Console.WriteLine("Địa chỉ không được chứa khoảng trắng liên tiếp!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbDiaChi, @"[^a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễỆỉỊọỏốồổỗộớờởỡợụủứừửữự\s]"))
            {
                Console.WriteLine("Địa chỉ không được chứa ký tự đặc biệt!");
                return false;
            }
            if (tbDiaChi.Length > 255)
            {
                Console.WriteLine("Địa chỉ không được dài quá 255 ký tự!");
                return false;
            }

            // Kiểm tra Số điện thoại
            if (string.IsNullOrWhiteSpace(tbSoDt))
            {
                Console.WriteLine("Số điện thoại sinh viên không được để trống!");
                return false;
            }
            if (tbSoDt.Contains(" "))
            {
                Console.WriteLine("Số điện thoại không được chứa khoảng trắng!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbSoDt.Trim(), @"[a-zA-Z]"))
            {
                Console.WriteLine("Số điện thoại không được chứa chữ cái!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbSoDt.Trim(), @"[^0-9]"))
            {
                Console.WriteLine("Số điện thoại không được chứa ký tự đặc biệt!");
                return false;
            }
            if (!tbSoDt.StartsWith("0"))
            {
                Console.WriteLine("Số điện thoại phải bắt đầu bằng số 0!");
                return false;
            }
            if (tbSoDt.Length != 10)
            {
                Console.WriteLine("Số điện thoại phải đúng 10 ký tự!");
                return false;
            }

            // Kiểm tra Email
            string email = tbEmail.Trim();
            string[] emailParts = email.Split('@');

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email sinh viên không được để trống!");
                return false;
            }
            if (!email.Contains("@") || emailParts.Length != 2 || string.IsNullOrEmpty(emailParts[0]) || string.IsNullOrEmpty(emailParts[1]))
            {
                Console.WriteLine("Email không hợp lệ!");
                return false;
            }
            if (email.Length > 254 || email.Contains(" ") || emailParts[0].StartsWith(".") || emailParts[0].Contains("..") ||
                emailParts[1].StartsWith("-") || emailParts[1].Contains("..") || emailParts[1].EndsWith("-") ||
                !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                Console.WriteLine("Email không hợp lệ!");
                return false;
            }

            // Kiểm tra Giới tính
            if (!rdoNam)
            {
                Console.WriteLine("Giới tính không được để trống!");
                return false;
            }

            // Kiểm tra Mã lớp hành chính
            string[] validKhoaNhapHoc = { "59", "60", "61", "62", "63", "64" };
            string[] validMaNganh = { "KTPM", "CNTT", "HTTT", "CX", "QTDL", "KT", "CK" };
            string[] validLop = { "1", "2", "3", "4", "5" };

            if (string.IsNullOrWhiteSpace(maLopHanhChinh))
            {
                Console.WriteLine("Mã lớp hành chính không được để trống!");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(maLopHanhChinh, @"[^a-zA-Z0-9]"))
            {
                Console.WriteLine("Mã lớp hành chính không được chứa ký tự đặc biệt!");
                return false;
            }
            if (maLopHanhChinh.Length > 10)
            {
                Console.WriteLine("Mã lớp hành chính không được dài quá 10 ký tự!");
                return false;
            }
            if (!validKhoaNhapHoc.Contains(maLopHanhChinh.Substring(0, 2)) ||
                !validMaNganh.Contains(maLopHanhChinh.Substring(2, 4)) ||
                !validLop.Contains(maLopHanhChinh.Substring(6, 1)))
            {
                Console.WriteLine("Mã lớp hành chính không hợp lệ!");
                return false;
            }

            // Nếu tất cả đều hợp lệ
            return true;
        }



        public static string KiemTraTimKiem(string maSV, string hoTen, string maLopHanhChinh, string khoa)
        {
            // Trường hợp 1: Mã sinh viên hợp lệ, tên sinh viên trống, mã lớp hành chính trống, khoa trống
            if (!string.IsNullOrEmpty(maSV) && string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(maLopHanhChinh) && string.IsNullOrEmpty(khoa))
            {
                return "Hiển thị thông tin sinh viên có mã sinh viên tương ứng";
            }
            // Trường hợp 2: Mã sinh viên trống, tên sinh viên hợp lệ, mã lớp hành chính trống, khoa trống
            else if (string.IsNullOrEmpty(maSV) && !string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(maLopHanhChinh) && string.IsNullOrEmpty(khoa))
            {
                return "Hiển thị danh sách sinh viên có tên trùng khớp";
            }
            // Trường hợp 3: Mã sinh viên trống, tên sinh viên trống, mã lớp hành chính hợp lệ, khoa trống
            else if (string.IsNullOrEmpty(maSV) && string.IsNullOrEmpty(hoTen) && !string.IsNullOrEmpty(maLopHanhChinh) && string.IsNullOrEmpty(khoa))
            {
                return "Hiển thị danh sách sinh viên thuộc mã lớp hành chính tương ứng";
            }
            // Trường hợp 4: Mã sinh viên trống, tên sinh viên trống, mã lớp hành chính trống, khoa hợp lệ
            else if (string.IsNullOrEmpty(maSV) && string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(maLopHanhChinh) && !string.IsNullOrEmpty(khoa))
            {
                return "Hiển thị danh sách sinh viên thuộc khoa tương ứng";
            }
            // Trường hợp 5: Mã sinh viên hợp lệ, tên sinh viên hợp lệ, mã lớp hành chính hợp lệ, khoa hợp lệ
            else if (!string.IsNullOrEmpty(maSV) && !string.IsNullOrEmpty(hoTen) && !string.IsNullOrEmpty(maLopHanhChinh) && !string.IsNullOrEmpty(khoa))
            {
                return "Hiển thị thông tin sinh viên phù hợp với cả 4 tiêu chí";
            }
            // Trường hợp 6: Mã sinh viên không hợp lệ, tên sinh viên trống, mã lớp hành chính trống, khoa trống
            else if (maSV.Length < 5 && string.IsNullOrEmpty(hoTen) && string.IsNullOrEmpty(maLopHanhChinh) && string.IsNullOrEmpty(khoa))
            {
                return "Không tìm thấy sinh viên";
            }
            // Trường hợp 7: Mã sinh viên trống, tên sinh viên không hợp lệ, mã lớp hành chính trống, khoa trống
            else if (string.IsNullOrEmpty(maSV) && hoTen.Length < 3 && string.IsNullOrEmpty(maLopHanhChinh) && string.IsNullOrEmpty(khoa))
            {
                return "Không tìm thấy sinh viên";
            }
            // Trường hợp không khớp với điều kiện nào
            else
            {
                return "Dữ liệu không hợp lệ";
            }
        }
        public static bool KiemTraXoa(string maSV)
        {
            if (maSV == "1")
            {
                return true;
            }
            else if (maSV == "2")
            {
                return true;
            }
            return false;
        }

    }
}
