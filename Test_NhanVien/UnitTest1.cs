using NUnit.Framework;
using _1.DAL.Models;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _2.BUS.IServices;
using _3.GUI.View.FrmNhanvien;
using _3.GUI.View;
using _3.GUI.View.FromSanPham;

namespace Test_NhanVien
{
    public class Tests
    {
        private IQLnhanVienServices _QlNVSV;
        private FrmNV _frmNV;

        [SetUp]
        public void Setup()
        {
            _QlNVSV = new QLnhanVienServices();
            _frmNV = new FrmNV();
            _frmNV.loadDuLieu();
        }
        // Test case 1: Thêm nhân viên thành công
        [Test]
        public void TestAddThanhCong()
        {
            _frmNV.tb_ten.Text = "Grunt23";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872889";
            _frmNV.tb_email.Text = "phucnhph32940@fpt.edu.vn";
            _frmNV.tb_matkhau.Text = "1234aaaa";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.SDT == "0961872399");
            Assert.IsNotNull(employee);
        }
        
        [Test]
        public void TestAdd_ChekSđt()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872373";
            _frmNV.tb_email.Text = "phucnhph32940@fpt.edu.vn";
            _frmNV.tb_matkhau.Text = "1234";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.TenNV == "Grunt");
            Assert.IsNotNull(employee);
        }

        // Test case 2: Thêm nhân viên không thành công với trườg tên trống
        [Test]
        public void AddTenTrong()
        {
            _frmNV.tb_ten.Text = "";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872373";
            _frmNV.tb_email.Text = "phucnhph32940@fpt.edu.vn";
            _frmNV.tb_matkhau.Text = "1234";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.TenNV == "");
            Assert.IsNull(employee);
        }

        // Tương tự, viết test case 3, 4, 5 cho các trường hợp còn lại tương tự như test case 2

        // Test case 3: Thêm nhân viên không thành công với trường địa chỉ trống
        [Test]
        public void TestAddEmployee_InvalidAddress()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "";
            _frmNV.tb_sdt.Text = "0961872373";
            _frmNV.tb_email.Text = "phucnhph32940@fpt.edu.vn";
            _frmNV.tb_matkhau.Text = "1234";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.diaChi == "");
            Assert.IsNull(employee);
        }

        // Test case 4: Thêm nhân viên không thành công với trường SĐT trống
        [Test]
        public void TestAdd_SDT()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "";
            _frmNV.tb_email.Text = "phucnhph32940@fpt.edu.vn";
            _frmNV.tb_matkhau.Text = "1234";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.SDT == "");
            Assert.IsNull(employee);
        }

        // Test case 5: email trống
        [Test]
        public void TestAdd_Email ()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872373";
            _frmNV.tb_email.Text = "";
            _frmNV.tb_matkhau.Text = "1234";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.email == "");
            Assert.IsNull(employee);
        }
        [Test]
        public void TestAdd_Pass()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872373";
            _frmNV.tb_email.Text = "Grunt@gmail.com";
            _frmNV.tb_matkhau.Text = "";
            _frmNV.rd_hd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.email == "");
            Assert.IsNull(employee);
        }

        [Test]
        public void TestAdd_CheckKoHoatDong()
        {
            _frmNV.tb_ten.Text = "Grunt";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872374";
            _frmNV.tb_email.Text = "Grunt@gmail.com";
            _frmNV.tb_matkhau.Text = "aaaaaa";
            _frmNV.rd_khd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            _frmNV.button1_Click(null, null);

            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.matKhau == "aaaaaa");
            Assert.IsNull(employee);
        }

        // Test case 1: Sửa nhân viên thành công
        [Test]
        public void TestEditEmployee_Successful()
        {
            // Arrange
          
            var employee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.TenNV == "Grunt");

            
            _frmNV.loadDuLieu();
            _frmNV.tb_ten.Text = "Nguyen Van B";
            _frmNV.tb_diachi.Text = "Hiệp Hòa";
            _frmNV.tb_sdt.Text = "0961872374";
            _frmNV.tb_email.Text = "Grunt@gmail.com";
            _frmNV.tb_matkhau.Text = "aaaaaa";
            _frmNV.rd_khd.Checked = true;
            _frmNV.cbb_cv.SelectedIndex = 1;
            // Act
            _frmNV.btn_sua_Click(null, null); // Gọi hàm xử lý cập nhật thông tin nhân viên


            var updatedEmployee = _QlNVSV.GetNhanVienFromDB().FirstOrDefault(x => x.nhanViens.TenNV == employee.nhanViens.TenNV);
            Assert.IsTrue(updatedEmployee.nhanViens.SDT == "0987654321");
        }
        [Test]
       
        public void sửathôngtinthànhcôngkhichuyểntừtênnàysangtênkhác()
        {
            
        }
    }
}
