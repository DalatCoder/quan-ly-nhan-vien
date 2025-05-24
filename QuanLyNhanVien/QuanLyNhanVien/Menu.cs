namespace QuanLyNhanVien;

public class Menu
{
    private DanhSachNhanVien _quanLyNhanVien = new DanhSachNhanVien();

    public void XuatMenu()
    {
        Console.WriteLine("===========CHUONG TRINH QUAN LY NHAN VIEN===========");
        Console.WriteLine($"{(int)ChucNang.ThoatChuongTrinh}. Thoat chuong trinh");
        Console.WriteLine($"{(int)ChucNang.NhapNhanVienTuFile}. Nhap nhan vien tu File");
        Console.WriteLine($"{(int)ChucNang.HienThiDanhSachNhanVien}. Hien thi danh sach nhan vien");
        Console.WriteLine($"{(int)ChucNang.TimDanhSachNhanVienTreTuoiNhat}. Tim danh sach nhan vien tre tuoi nhat");
        Console.WriteLine($"{(int)ChucNang.SapXepDanhSachNhanVien}. Sap xep danh sach nhan vien theo nam sinh va ten");
        Console.WriteLine(
            $"{(int)ChucNang.XoaNhungNhanVienCoNhieuNguoiThanNhat}. Xoa nhung nhan vien co nhieu nguoi than nhat");
        Console.WriteLine($"{(int)ChucNang.TimNhungNhanVienKhongCoNguoiThan}. Tim nhung nhan vien khong co nguoi than");
        Console.WriteLine($"{(int)ChucNang.ThongKeNhanVienTheoNamSinh}. Thong ke nhan vien theo nam sinh");
        Console.WriteLine("====================================================");
    }

    public ChucNang ChonChucNang()
    {
        Console.Write("\nHay chon chuc nang mong muon: ");

        // "1" -> 1 -> ChucNang.NhapNhanVienTuFile
        // "abc" -> Exception
        string chucNang = Console.ReadLine();
        int chucNangDangSo = int.Parse(chucNang);

        return (ChucNang)chucNangDangSo;
    }

    public void XuLyChucNang(ChucNang chucNangDaChon)
    {
        switch (chucNangDaChon)
        {
            case ChucNang.ThoatChuongTrinh:
                Console.WriteLine("Cam on da su dung chuong trinh");
                break;

            case ChucNang.NhapNhanVienTuFile:
                _quanLyNhanVien.DocDanhSachNhanVienTuFile();
                Console.WriteLine("Doc danh sach nhan vien thanh cong");
                break;

            case ChucNang.HienThiDanhSachNhanVien:
                _quanLyNhanVien.HienThiDanhSachNhanVien();
                break;

            case ChucNang.TimDanhSachNhanVienTreTuoiNhat:
                _quanLyNhanVien.TimDanhSachNhanVienTreTuoiNhat();
                break;

            case ChucNang.SapXepDanhSachNhanVien:
                Console.WriteLine("Danh sach nhan vien truoc khi sap xep");
                _quanLyNhanVien.HienThiDanhSachNhanVien();

                Console.WriteLine("\nDanh sach nhan vien sau khi sap xep");
                _quanLyNhanVien.SapXepDanhSachNhanVien();
                _quanLyNhanVien.HienThiDanhSachNhanVien();
                break;

            case ChucNang.XoaNhungNhanVienCoNhieuNguoiThanNhat:
                Console.WriteLine("Danh sach nhan vien truoc khi xoa");
                _quanLyNhanVien.HienThiDanhSachNhanVien();

                _quanLyNhanVien.XoaDanhSachNhanVienCoNhieuNguoiThanNhat();
                Console.WriteLine("\nDanh sach nhan vien sau khi xoa");
                _quanLyNhanVien.HienThiDanhSachNhanVien();
                break;

            case ChucNang.TimNhungNhanVienKhongCoNguoiThan:
                Console.WriteLine("Danh sach nhan vien hien tai");
                _quanLyNhanVien.HienThiDanhSachNhanVien();
                
                _quanLyNhanVien.TimDanhSachNhanVienKhongCoNguoiThanLamCungCongTy();
                break;

            case ChucNang.ThongKeNhanVienTheoNamSinh:
                Console.WriteLine("Danh sach nhan vien hien tai");
                _quanLyNhanVien.HienThiDanhSachNhanVien();
                
                _quanLyNhanVien.ThongKeSoLuongNhanVienTheoNamSinh();
                break;

            default:
                Console.WriteLine("Chuc nang da chon khong hop le, vui long chon chuc nang khac");
                break;
        }
    }

    public void ChayChuongTrinh()
    {
        while (true)
        {
            Console.Clear();
            XuatMenu();
            ChucNang chucNang = ChonChucNang();

            Console.Clear();
            XuLyChucNang(chucNang);

            if (chucNang == ChucNang.ThoatChuongTrinh)
                break;

            Console.Write("\nHay nhan phim bat ky de tiep tuc chuong trinh");
            Console.ReadKey();
        }
    }
}