using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BTL
{
    public partial class formSV : Form
    {

        string constr = ConnectString.GetConnectionString();
        public formSV()
        {
            InitializeComponent();
        }
        void Load_DB_toGridView()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("select * from SinhVien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ada.Fill(tb);
                      
                        dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        //foreach (DataGridViewColumn col in dgvSV.Columns)
                        //    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                        dgvSV.DataSource = tb;
                        dgvSV.Columns[0].HeaderText = "Mã Sinh Viên";
                        dgvSV.Columns[1].HeaderText = "Họ Tên";
                        dgvSV.Columns[2].HeaderText = "Ngày Sinh (mm/dd/yy)";
                        dgvSV.Columns[3].HeaderText = "Giới Tính";
                        dgvSV.Columns[4].HeaderText = "Địa Chỉ";
                        dgvSV.Columns[5].HeaderText = "Số ĐT";
                        dgvSV.Columns[6].HeaderText = "Email";
                        dgvSV.Columns[7].HeaderText = "Lớp HC";
                      
                       
                        dgvSV.ReadOnly = true;
                     
                    }
                }
            }
        }
        void Load_combo_Khoa()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Khoa", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        //load tên khoa vào combobox phần tìm kiếm
                        cbbTimTheoKhoa.DataSource = tb;
                        cbbTimTheoKhoa.DisplayMember = "tenKhoa"; 
                        cbbTimTheoKhoa.ValueMember = "maKhoa";
                    }
                }
            }

        }
       
        void Load_combo_lop()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LopHanhChinh", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);                      
                        cbbMaLopHC.DataSource = tb;
                        cbbMaLopHC.DisplayMember = "maLopHC";
                        cbbMaLopHC.ValueMember = "maLopHC";
                    }
                }
            }

        }
        void refresh()
        {
            tbMaSV.ResetText();
            tbHoTen.ResetText();
            tbNgaysinh.Text = "mm/dd/yyyy"; tbNgaysinh.ForeColor = Color.Gray;
            tbDiaChi.ResetText();
            tbDiaChi.ResetText();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            tbSoDt.ResetText();
            tbEmail.ResetText();      
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            tbMaSV.Enabled = true;
        }




        public void label2_Click(object sender, EventArgs e)
        {

        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void label7_Click(object sender, EventArgs e)
        {

        }

        public void label12_Click(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void formSV_Load(object sender, EventArgs e)
        {
            Load_DB_toGridView();
            Load_combo_Khoa();
            Load_combo_lop();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        //public int kiemtra() // kiểm tra xam khóa chính, mã sv có tồn tại không không - có return 1.
        //{
        //    string pk = tbMaSv.Text.Trim();
        //    string sql = "select * from SinhVien where maSV='" + pk.ToString() + "'";
        //    using (SqlConnection cnn = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sql, cnn))
        //        {
        //            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        //            {
        //                DataTable tb = new DataTable();
        //                ad.Fill(tb);
        //                if (tb.Rows.Count > 0)
        //                    return 1;
        //                else return 0;
        //            }
        //        }
        //    }
        //}

        //hàm kiểm tra tính đúng đắn của dữ liệu nhập vào trong các textbox.
        public bool KiemTraDuLieu()
        {
            //Mã sinh viên
            // Mảng chứa khóa nhập học và mã ngành hợp lệ
                  string[] khoaNhapHoc = { "225", "215", "235","245","205" };  // Ví dụ: khóa nhập học hợp lệ (3 ký tự đầu)
                  string[] maNganh = { "117", "116", "115","114","113","112","111","110","241","242","234","125","127","129","102","103","104" };      // Ví dụ: mã ngành hợp lệ (3 ký tự tiếp theo)
                   if (tbMaSV.Text.Trim() == "")
                  {
                      MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      return false;
                  }
                  else if (tbMaSV.Text.Trim().Length != 10)
                  {
                        MessageBox.Show("Mã sinh viên phải có đúng 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (System.Text.RegularExpressions.Regex.IsMatch(tbMaSV.Text.Trim(), @"[^a-zA-Z0-9]"))
                    {
                        MessageBox.Show("Mã sinh viên không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (tbMaSV.Text.Trim().Contains(" "))
                    {
                        MessageBox.Show("Mã sinh viên không được chứa khoảng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        string maSinhVien = tbMaSV.Text.Trim();
                        string khoaNhap = maSinhVien.Substring(0, 3);  // 3 ký tự đầu (khóa nhập học)
                        string maNganhSinhVien = maSinhVien.Substring(3, 3);   // 3 ký tự tiếp theo (mã ngành)
                        string bonKyTuCuoi = maSinhVien.Substring(6, 4); // 4 ký tự cuối
            
                        if (!khoaNhapHoc.Contains(khoaNhap))
                        {
                            MessageBox.Show("Khóa nhập học không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
            
                        }
            
                        else if (!maNganh.Contains(maNganhSinhVien))
                        {
                            MessageBox.Show("Mã ngành không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
            
                        }
                       else
                            return true; 
                        
                            
                            
                        
                        
                  }



            //Tên sinh viên
            if (tbHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (tbHoTen.Text.Trim().Length > 40)
            {
                MessageBox.Show("Họ tên sinh viên không được dài hơn 40 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbHoTen.Text.Trim(), @"\s{2,}"))
            {
                MessageBox.Show("Họ tên sinh viên không được chứa khoảng trắng liên tiếp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbHoTen.Text.Trim(), @"[^a-zA-Z\s]"))
            {
                MessageBox.Show("Họ tên sinh viên không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }



//Ngày sinh

            if (tbNgaysinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(tbNgaysinh.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng dd/MM/yyyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;  // Điều chỉnh tuổi nếu sinh nhật chưa đến trong năm nay
                if (tuoi < 17)
                {
                    MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int ngay = ngaySinh.Day;
                if (ngay < 1 || ngay > DateTime.DaysInMonth(ngaySinh.Year, ngaySinh.Month))
                {
                    MessageBox.Show("Ngày không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int thang = ngaySinh.Month;
                if (thang < 1 || thang > 12)
                {
                    MessageBox.Show("Tháng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int nam = ngaySinh.Year;
                if (thang == 2 && ngay == 29 && !DateTime.IsLeapYear(nam))
                {
                    MessageBox.Show("Năm không phải năm nhuận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }

//địa chỉ
            if (tbDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbDiaChi.Text.Trim(), @"\s{2,}"))
            {
                MessageBox.Show("Địa chỉ không được chứa khoảng trắng liên tiếp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbDiaChi.Text.Trim(), @"[^a-zA-Z0-9\s,./]"))
            {
                MessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (tbDiaChi.Text.Trim().Length > 255)
            {
                MessageBox.Show("Địa chỉ không được dài quá 255 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }

//Số điện thoại

            if (tbSoDt.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (tbSoDt.Text.Contains(" "))
            {
                MessageBox.Show("Số điện thoại không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbSoDt.Text.Trim(), @"[a-zA-Z]"))
            {
                MessageBox.Show("Số điện thoại không được chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbSoDt.Text.Trim(), @"[^0-9]"))
            {
                MessageBox.Show("Số điện thoại không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!tbSoDt.Text.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (tbSoDt.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }



            //email
            string email = tbEmail.Text.Trim();
            string[] emailParts = email.Split('@');

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!email.Contains("@") || emailParts.Length != 2 || string.IsNullOrEmpty(emailParts[0]) || string.IsNullOrEmpty(emailParts[1]))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (email.Length > 254 || email.Contains(" ") ||
                     emailParts[0].StartsWith(".") || emailParts[0].Contains("..") ||
                     emailParts[1].StartsWith("-") || emailParts[1].Contains("..") ||
                     emailParts[1].EndsWith("-") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                return true;
            }

            return false;


            //giới tính

            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Giới tính giảng viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Mã lớp hành chính

           // g các ký tự hợp lệ cho khóa nhập học và ngành
              string[] validKhoaNhapHoc = { "59", "60", "61","62","63","64" }; // Thay đổi giá trị theo yêu cầu
              string[] validMaNganh = { "KTPM", "CNTT", "HTTT", "CX", "QTDL", "KT", "CK" }; // Thay đổi giá trị theo yêu cầu
              string[] validLop = { "1", "2", "3", "4", "5" }; // Thay đổi giá trị theo yêu cầu
                          if (maLopHanhChinh.Text.Trim() == "")
              {
                MessageBox.Show("Mã lớp hành chính không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return false;
              }
               else if (System.Text.RegularExpressions.Regex.IsMatch(maLopHanhChinh.Text, @"[^a-zA-Z0-9]"))
               {
                   MessageBox.Show("Mã lớp hành chính không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return false;
               }
               else if (System.Text.RegularExpressions.Regex.IsMatch(maLopHanhChinh.Text, @"\s"))
               {
                   MessageBox.Show("Mã lớp hành chính không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return false;
               }
               else if (maLopHanhChinh.Text.Length > 10)
               {
                   MessageBox.Show("Mã lớp hành chính không được nhiều hơn 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return false;
               }
               else if (maLopHanhChinh.Text.Length >= 5)
               {
                   string firstTwoChars = maLopHanhChinh.Text.Substring(0, 2);
                   string middlePart = maLopHanhChinh.Text.Substring(2, maLopHanhChinh.Text.Length - 3); // Các ký tự giữa
                   char lastChar = maLopHanhChinh.Text[maLopHanhChinh.Text.Length - 1];
                   bool isFirstTwoValid = validKhoaNhapHoc.Contains(firstTwoChars);
                   // Kiểm tra các ký tự tiếp theo có hợp lệ không 
                   bool isMiddlePartValid = validMaNganh.Contains(middlePart);
                   // Kiểm tra ký tự cuối cùng có hợp lệ không
                   bool isLastCharValid = validLop.Contains(lastChar.ToString());
                  if (!isFirstTwoValid)    
                  {    
                      MessageBox.Show("2 ký tự đầu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      return false; 
                  } 
                  else if (!isMiddlePartValid) 
                  { 
                      MessageBox.Show("Các ký tự tiếp theo không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                      return false; 
                  } 
                  else if (!isLastCharValid) 
                  { 
                      MessageBox.Show("Ký tự cuối không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                     return false; 
                 } 
                  } 
                    else 
                   { 
                  return true; 
                   } 
                
                
                

        }
        public void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu() == false)
                return;

            string query = "select * from SinhVien";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(query, cnn);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "sv");
                    DataTable dt = ds.Tables["sv"];

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["maSV"].ToString().Trim() == tbMaSV.Text.Trim())
                        {
                            row["tenSV"] = tbHoTen.Text.Trim();
                            row["ngaySinh"] = tbNgaysinh.Text.Trim();
                            if (rdoNam.Checked)
                                row["gioiTinh"] = "Nam";
                            else
                                row["gioiTinh"] = "Nữ";
                            row["diaChi"] = tbDiaChi.Text.Trim();
                            row["soDienThoai"] = tbSoDt.Text.Trim();
                            row["email"] = tbEmail.Text.Trim();                 
                            row["maLopHC_FK"] = cbbMaLopHC.SelectedValue;
                            break;
                        }
                    }
                    da.Update(ds, "sv");
                    Load_DB_toGridView();
                    refresh();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ, lỗi là:" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //kiểm tra xem có click vào dòng mới ở dưới cùng không.        
            if (dgvSV.CurrentRow.Cells["maSV"].Value.ToString() != "")
            {
                tbMaSV.Text = dgvSV.CurrentRow.Cells["maSV"].Value.ToString().Trim();
                tbMaSV.Enabled = false;
                tbHoTen.Text = dgvSV.CurrentRow.Cells["tenSV"].Value.ToString().Trim();
                tbNgaysinh.Text = dgvSV.CurrentRow.Cells["ngaySinh"].Value.ToString(); tbNgaysinh.ForeColor = Color.Black;
                tbDiaChi.Text = dgvSV.CurrentRow.Cells["diaChi"].Value.ToString().Trim();
                tbSoDt.Text = dgvSV.CurrentRow.Cells["soDienThoai"].Value.ToString().Trim();
                tbEmail.Text = dgvSV.CurrentRow.Cells["email"].Value.ToString().Trim();
                cbbMaLopHC.SelectedValue = dgvSV.CurrentRow.Cells["maLopHC_FK"].Value.ToString();
              
                if (dgvSV.CurrentRow.Cells["gioiTinh"].Value.ToString().Trim().Equals("nam", StringComparison.InvariantCultureIgnoreCase))
                    rdoNam.Checked = true;
                else rdoNu.Checked = true;

                btnSua.Enabled = true;             
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
            else
            {
                refresh();
            }
        }

       public void btnXoa_Click(object sender, EventArgs e)
        {
      DialogResult kq = MessageBox.Show("Bạn có muốn xóa không?", "Thong bao", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
      if (kq == DialogResult.Yes)
      {
          using (SqlConnection cnn = new SqlConnection(constr))
          {          
              string query = @"delete from SinhVien where maSV=N'"+tbMaSV.Text.Trim()+"'";
              using (SqlCommand cmd =new SqlCommand(query,cnn))
              {
                  cmd.CommandType = CommandType.Text;
                   cnn.Open();
                   cmd.ExecuteNonQuery();
                   Load_DB_toGridView();
                   refresh();
               }
           }
       }
     }

        public void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu() == false)
                return;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string query = "select * from SinhVien";
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(query, cnn);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "sv");
                    DataTable dt = ds.Tables["sv"];
                    DataRow row = dt.NewRow();
                    row["maSV"] = tbMaSV.Text.Trim();
                    row["tenSV"] = tbHoTen.Text.Trim();
                    row["ngaySinh"] = tbNgaysinh.Text.Trim();
                    if (rdoNam.Checked)
                        row["gioiTinh"] = "Nam";
                    else
                        row["gioiTinh"] = "Nữ";
                    row["diaChi"] = tbDiaChi.Text.Trim();
                    row["soDienThoai"] = tbSoDt.Text.Trim();
                    row["email"] = tbEmail.Text.Trim();
                    row["maLopHC_FK"] = cbbMaLopHC.SelectedValue;
 
                    dt.Rows.Add(row);
                    da.Update(ds, "sv");
                    Load_DB_toGridView();
                    refresh();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Thêm thất bại, lỗi là:" + err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void btnTatCa_Click(object sender, EventArgs e)
        {
            Load_DB_toGridView();
            refresh();
        }

        public void btnTimKiem_Click(object sender, EventArgs e)
        { 
            //tìm kiếm theo khoa
// 1            if(tbTimKiemTheoTen.Text.Trim() == "nhập tên hoặc mã sv" && tbTimTheoLop.Text.Trim() == "")
// 2            {     
// 3                string tim_sql = @"select maSV,tenSV,ngaySinh,gioiTinh,diaChi,sv.soDienThoai,email,maLopHC_FK,namNhapHocCuaSV,tenKhoa
// 4                                    from SinhVien sv,LopHanhChinh lhc, Khoa
// 5                                    where sv.maLopHC_FK=lhc.maLopHC and lhc.maKhoaFK= Khoa.maKhoa and maKhoa =N'" + cbbTimTheoKhoa.SelectedValue+"'";
// 6                using (SqlConnection cnn = new SqlConnection(constr))
// 7                {
// 8                    SqlDataAdapter sda = new SqlDataAdapter();
// 9                    sda.SelectCommand = new SqlCommand(tim_sql, cnn);
// 10                    DataTable tb = new DataTable();
// 11                    sda.Fill(tb);
// 12                   dgvSV.DataSource = tb;
// 13                   dgvSV.Columns[8].HeaderText = "Năm nhập học";
// 14                   dgvSV.Columns[9].HeaderText = "Khoa";                  
// 15                   refresh();
// 16               }
// 17           }
// 18           else if(tbTimKiemTheoTen.Text.Trim() != "nhập tên hoặc mã sv" && tbTimTheoLop.Text.Trim() == "")//tìm theo ten sv||ma sv kết hợp với tìm theo khoa
// 19           {
// 20               string tim_sql = @"select maSV,tenSV,ngaySinh,gioiTinh,diaChi,sv.soDienThoai,email,maLopHC_FK,namNhapHocCuaSV,tenKhoa
// 21                               from SinhVien sv,LopHanhChinh lhc, Khoa
// 22                               where sv.maLopHC_FK=lhc.maLopHC and lhc.maKhoaFK= Khoa.maKhoa and sv.maSV=N'" + tbTimKiemTheoTen.Text.Trim() + "'";//+ " and maKhoa=N'" + cbbTimTheoKhoa.SelectedValue + "'";
// 23               using (SqlConnection cnn = new SqlConnection(constr))
// 24               {
// 25                   SqlDataAdapter sda = new SqlDataAdapter();
// 26                   sda.SelectCommand = new SqlCommand(tim_sql, cnn);
// 27                   DataTable tb = new DataTable();
// 28                   sda.Fill(tb);
// 29                   if (tb.Rows.Count < 1)
// 30                   {
// 31                       string tim = @"select maSV,tenSV,ngaySinh,gioiTinh,diaChi,sv.soDienThoai,email,maLopHC_FK,namNhapHocCuaSV,tenKhoa
// 32                       from SinhVien sv,LopHanhChinh lhc, Khoa
// 33                       where sv.maLopHC_FK=lhc.maLopHC and lhc.maKhoaFK= Khoa.maKhoa and tenSV like N'%" + tbTimKiemTheoTen.Text.Trim() + "%'"+ " and maKhoa=N'" + cbbTimTheoKhoa.SelectedValue + "'"; 
// 34                       SqlDataAdapter da = new SqlDataAdapter();
// 35                       da.SelectCommand = new SqlCommand(tim, cnn);
// 36                       DataTable t = new DataTable();
// 37                       da.Fill(t);
// 38                       dgvSV.DataSource = t;
// 39                       dgvSV.Columns[8].HeaderText = "Năm nhập học";
// 40                       dgvSV.Columns[9].HeaderText = "Khoa";
// 41                       if (t.Rows.Count < 1)
// 42                         {
// 43                             MessageBox.Show("Không có kết quả trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
// 44                             return;
// 45                         }
// 46                         tbTimKiemTheoTen.Text = "nhập tên hoặc mã sv"; tbTimKiemTheoTen.ForeColor = Color.Gray;
// 47                         refresh();
// 48                        return;
// 49                     }
// 50                     dgvSV.DataSource = tb;
// 51                     dgvSV.Columns[8].HeaderText = "Năm nhập học";
// 52                    dgvSV.Columns[9].HeaderText = "Khoa";
// 53                    tbTimKiemTheoTen.Text = "nhập tên hoặc mã sv"; tbTimKiemTheoTen.ForeColor = Color.Gray;
// 54                    refresh();
// 55                }
// 56            }
// 57            else if(tbTimKiemTheoTen.Text.Trim() == "nhập tên hoặc mã sv" && tbTimTheoLop.Text.Trim()!="")//tìm sv theo lớp hc
// 58            {
// 59               string tim_sql = @"select maSV,tenSV,ngaySinh,gioiTinh,diaChi,sv.soDienThoai,email,maLopHC_FK,namNhapHocCuaSV,tenKhoa
// 60                                    from SinhVien sv,LopHanhChinh lhc, Khoa
// 61                                    where sv.maLopHC_FK=lhc.maLopHC and lhc.maKhoaFK= Khoa.maKhoa and lhc.maLopHC=N'" + tbTimTheoLop.Text.Trim() + "'"; //+"and maKhoa=N'"+cbbTimTheoKhoa.SelectedValue+"'"               
// 62                using (SqlConnection cnn = new SqlConnection(constr))
// 63                {
// 64                    SqlDataAdapter sda = new SqlDataAdapter();
// 65                    sda.SelectCommand = new SqlCommand(tim_sql, cnn);
// 66                    DataTable tb = new DataTable();
// 67                    sda.Fill(tb);
// 68                    dgvSV.DataSource = tb;
// 69                    dgvSV.Columns[8].HeaderText = "Năm nhập học";
// 70                    dgvSV.Columns[9].HeaderText = "Khoa";
// 71                    if (tb.Rows.Count < 1)
// 72                    {
// 73                        MessageBox.Show("Không có kết quả trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
// 74                        return;
// 75                    }
// 76                    tbTimTheoLop.Text = "";
// 77                    refresh();
// 78                }
// 79            }
// 80            else//tìm theo cả tên sv + tên lớp + tên khoa
// 81            {
// 82                using (SqlConnection cnn = new SqlConnection(constr))
// 83                {
// 84                                       string tim = @"select maSV,tenSV,ngaySinh,gioiTinh,diaChi,sv.soDienThoai,email,maLopHC_FK,namNhapHocCuaSV,tenKhoa
// 85                                        from SinhVien sv,LopHanhChinh lhc, Khoa
// 86                                        where sv.maLopHC_FK=lhc.maLopHC and lhc.maKhoaFK= Khoa.maKhoa and sv.maLopHC_FK=N'" + tbTimTheoLop.Text.Trim() +
// 87                                            "' and maKhoa=N'" + cbbTimTheoKhoa.SelectedValue + "' and tenSV like N'%" + tbTimKiemTheoTen.Text.Trim() + "%'";
// 88                        SqlDataAdapter da = new SqlDataAdapter();
// 89                        da.SelectCommand = new SqlCommand(tim, cnn);
// 90                        DataTable t = new DataTable();
// 91                        da.Fill(t);
// 92                       dgvSV.DataSource = t;
// 93                        if (t.Rows.Count < 1)
// 94                        {
// 95                            MessageBox.Show("Không có kết quả trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
// 96                            return;
// 97                        }                        
// 98                        tbTimKiemTheoTen.Text = "nhập tên hoặc mã sv"; tbTimKiemTheoTen.ForeColor = Color.Gray;
// 99                        tbTimTheoLop.Text = "";
// 100                        refresh();
// 9                }
            } 
        }

        public void tbTimKiemTheoTen_Enter(object sender, EventArgs e)
        {
            if (tbTimKiemTheoTen.Text == "nhập tên hoặc mã sv")
            {
                tbTimKiemTheoTen.Text = "";
                tbTimKiemTheoTen.ForeColor = Color.Black;
            }
        }

        public void tbTimKiemTheoTen_Leave(object sender, EventArgs e)
        {
            if (tbTimKiemTheoTen.Text == "")
            {
                tbTimKiemTheoTen.Text = "nhập tên hoặc mã sv";
                tbTimKiemTheoTen.ForeColor = Color.Gray;
            }
        }

        public void tbNgaysinh_Click(object sender, EventArgs e)
        {

        }

        public void tbNgaysinh_Enter(object sender, EventArgs e)
        {
            if (tbNgaysinh.Text == "mm/dd/yyyy")
            {
                tbNgaysinh.Text = "";
                tbNgaysinh.ForeColor = Color.Black;
            }
        }

        public void tbNgaysinh_Leave(object sender, EventArgs e)
        {

            if (tbNgaysinh.Text == "")
            {
                tbNgaysinh.Text = "mm/dd/yyyy";
                tbNgaysinh.ForeColor = Color.Gray;
            }
        }

        public void tbTimKiemTheoTen_TextChanged(object sender, EventArgs e)
        {

        }

        public void tbMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        public void cbbMaLopHC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void tbTimTheoLop_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
