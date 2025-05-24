namespace QuanLyNhanVien;

public class DanhSachNhanVien
{
    private List<INhanVien> _danhSachNhanVien;

    // indexer
    public INhanVien this[int index]
    {
        get { return _danhSachNhanVien[index]; }
        set { _danhSachNhanVien[index] = value; }
    }

    public DanhSachNhanVien()
    {
        _danhSachNhanVien = new List<INhanVien>();
    }

    public void DocDanhSachNhanVienTuFile()
    {
        string tenFile = "Data.txt";
        string[] noiDungFile = File.ReadAllLines(tenFile);

        foreach (string moiDong in noiDungFile)
        {
            string[] ketQuaTachChuoi = moiDong.Split(';');
            string loaiNhanVien = ketQuaTachChuoi[0];

            if (loaiNhanVien == "HopDong")
            {
                NhanVienHopDong nv = new NhanVienHopDong(moiDong);
                _danhSachNhanVien.Add(nv);
            }
            else if (loaiNhanVien == "TheoGio")
            {
                NhanVienTheoGio nv = new NhanVienTheoGio(moiDong);
                _danhSachNhanVien.Add(nv);
            }
        }
    }

    private void _hienThiDanhSach(List<INhanVien> danhSachNhanVien)
    {
        // in tieu de
        // STT | Loai NV | Ten NV | Ma so | Nam sinh | Luong | Ghi chu
        Console.WriteLine("{0,5} | {1,-10} | {2,-20} | {3,-10} | {4,8} | {5,20} | {6,-20}", "STT", "Loai NV", "Ten NV",
            "Ma so", "Nam sinh", "HS Luong/Tien cong", "Ghi chu");

        // in noi dung
        int stt = 1;
        foreach (INhanVien nhanVien in danhSachNhanVien)
        {
            string loaiNhanVien = "";
            string tenNhanVien = nhanVien.Ten;
            string maSo = nhanVien.MaSo;
            int namSinh = nhanVien.NamSinh;

            if (nhanVien is NhanVienHopDong)
            {
                NhanVienHopDong nhanVienHopDong = nhanVien as NhanVienHopDong;

                loaiNhanVien = "HopDong";
                float heSoLuong = nhanVienHopDong.HeSoLuong;
                string ghiChu = "Nguoi than: " + String.Join(", ", nhanVienHopDong.DanhSachNguoiThan);

                Console.WriteLine("{0,5} | {1,-10} | {2,-20} | {3,-10} | {4,8} | {5,20} | {6,-20}", stt, loaiNhanVien,
                    tenNhanVien, maSo, namSinh, heSoLuong, ghiChu);
            }

            else if (nhanVien is NhanVienTheoGio)
            {
                NhanVienTheoGio nhanVienTheoGio = nhanVien as NhanVienTheoGio;

                loaiNhanVien = "TheoGio";
                int tienCongTheoGio = nhanVienTheoGio.TienCongTheoGio;
                string ghiChu = "Cong viec: " + String.Join(", ", nhanVienTheoGio.DanhSachCongViec);

                Console.WriteLine("{0,5} | {1,-10} | {2,-20} | {3,-10} | {4,8} | {5,20} | {6,-20}", stt, loaiNhanVien,
                    tenNhanVien, maSo, namSinh, tienCongTheoGio, ghiChu);
            }

            stt += 1;
        }
    }

    public void HienThiDanhSachNhanVien()
    {
        _hienThiDanhSach(_danhSachNhanVien);
    }

    public void TimDanhSachNhanVienTreTuoiNhat()
    {
        // kiem tra danh sach nhan vien
        if (_danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Hien khong co nhan vien nao trong danh sach");
            return;
        }

        // tim nam sinh lon nhat: 2005
        int namSinhLonNhat = _danhSachNhanVien[0].NamSinh;

        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            if (nhanVien.NamSinh > namSinhLonNhat)
                namSinhLonNhat = nhanVien.NamSinh;
        }

        // tim ra nhung nhan vien thoa dieu kien
        List<INhanVien> ketQua = new List<INhanVien>();

        foreach (INhanVien nhanVien in _danhSachNhanVien)
            if (nhanVien.NamSinh == namSinhLonNhat)
                ketQua.Add(nhanVien);

        // in danh sach ket qua
        Console.WriteLine("\nDanh sach nhan vien tre tuoi");
        _hienThiDanhSach(ketQua);
    }

    public void SapXepDanhSachNhanVien()
    {
        // Bubble sort
        for (int i = 0; i < _danhSachNhanVien.Count; i++)
        {
            for (int j = i + 1; j < _danhSachNhanVien.Count; j++)
            {
                bool dk1 = _danhSachNhanVien[i].NamSinh < _danhSachNhanVien[j].NamSinh;
                bool dk2 = (_danhSachNhanVien[i].NamSinh == _danhSachNhanVien[j].NamSinh) &&
                           (_danhSachNhanVien[i].Ten.CompareTo(_danhSachNhanVien[j].Ten) > 0);

                if (dk1 || dk2)
                {
                    INhanVien tmp = _danhSachNhanVien[i];
                    _danhSachNhanVien[i] = _danhSachNhanVien[j];
                    _danhSachNhanVien[j] = tmp;
                }
            }
        }
    }

    public void XoaDanhSachNhanVienCoNhieuNguoiThanNhat()
    {
        // kiem tra danh sach nhan vien rong
        if (_danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Hien tai khong co nhan vien trong danh sach");
            return;
        }

        // tim ra so luong nguoi than lon nhat => 3
        int soLuongNguoiThanLonNhat = -1;

        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            if (nhanVien is NhanVienHopDong)
            {
                NhanVienHopDong nvHopDong = nhanVien as NhanVienHopDong;

                if (nvHopDong.DanhSachNguoiThan.Count > soLuongNguoiThanLonNhat)
                    soLuongNguoiThanLonNhat = nvHopDong.DanhSachNguoiThan.Count;
            }
        }

        // loc danh sach
        List<INhanVien> nhanVienThoaDieuKien = new List<INhanVien>();

        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            if (nhanVien is NhanVienTheoGio)
            {
                nhanVienThoaDieuKien.Add(nhanVien);
            }
            else if (nhanVien is NhanVienHopDong)
            {
                // Nhan vien hop dong
                NhanVienHopDong nhanVienHopDong = nhanVien as NhanVienHopDong;
                if (nhanVienHopDong.DanhSachNguoiThan.Count < soLuongNguoiThanLonNhat)
                {
                    nhanVienThoaDieuKien.Add(nhanVien);
                }
            }
        }


        // cap nhat
        _danhSachNhanVien = nhanVienThoaDieuKien;
    }

    private bool _nhanVienCoTonTaiTrongCongTyHayKhong(string tenNhanVien)
    {
        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            if (nhanVien.Ten.ToLower().Trim() == tenNhanVien.ToLower().Trim())
                return true;
        }

        return false;
    }

    public void TimDanhSachNhanVienKhongCoNguoiThanLamCungCongTy()
    {
        // kiem tra
        if (_danhSachNhanVien.Count == 0)
        {
            Console.WriteLine("Hien tai khong co nhan vien");
            return;
        }

        List<INhanVien> nhanVienThoaDieuKien = new List<INhanVien>();

        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            if (nhanVien is NhanVienTheoGio)
            {
                nhanVienThoaDieuKien.Add(nhanVien);
            }

            else if (nhanVien is NhanVienHopDong)
            {
                NhanVienHopDong nhanVienHopDong = nhanVien as NhanVienHopDong;
                bool coNguoiThanLamCungCongTyHayKhong = false;

                foreach (string tenNguoiThan in nhanVienHopDong.DanhSachNguoiThan)
                {
                    bool coTonTai = _nhanVienCoTonTaiTrongCongTyHayKhong(tenNguoiThan);
                    if (coTonTai)
                    {
                        coNguoiThanLamCungCongTyHayKhong = true;
                        break;
                    }
                }

                if (coNguoiThanLamCungCongTyHayKhong == false)
                {
                    nhanVienThoaDieuKien.Add(nhanVien);
                }
            }
        }

        Console.WriteLine("\nDanh sach nhan vien khong co nguoi than lam cung cong ty");
        _hienThiDanhSach(nhanVienThoaDieuKien);
    }

    public void ThongKeSoLuongNhanVienTheoNamSinh()
    {
        Dictionary<int, int> thongKe = new Dictionary<int, int>();

        foreach (INhanVien nhanVien in _danhSachNhanVien)
        {
            int namSinh = nhanVien.NamSinh;

            if (thongKe.ContainsKey(namSinh) == false)
            {
                thongKe.Add(namSinh, 0);
            }

            thongKe[namSinh] += 1;
        }

        Console.WriteLine("\nThong ke so luong nhan vien theo nam sinh");

        // STT, Nam sinh, So luong
        Console.WriteLine("{0,5} | {1,10} | {2,10}", "STT", "Nam sinh", "So luong");

        int stt = 1;
        foreach (int namSinh in thongKe.Keys)
        {
            int soLuongNhanVien = thongKe[namSinh];
            Console.WriteLine("{0,5} | {1,10} | {2,10}", stt, namSinh, soLuongNhanVien);

            stt += 1;
        }
    }
}