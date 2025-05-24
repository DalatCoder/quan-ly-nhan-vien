namespace QuanLyNhanVien;

public class NhanVienHopDong : INhanVien
{
    // Fields
    private List<string> _danhSachNguoiThan = new List<string>();
    private float _heSoLuong;
    private string _maSo;
    private int _namSinh;
    private string _ten;

    // Properties
    public string MaSo
    {
        get { return _maSo; }
    }

    public int NamSinh
    {
        get { return _namSinh; }
        set { _namSinh = value; }
    }

    public string Ten
    {
        get { return _ten; }
        set { _ten = value; }
    }

    public float HeSoLuong
    {
        get { return _heSoLuong; }
        set { _heSoLuong = value; }
    }

    public List<string> DanhSachNguoiThan
    {
        get { return _danhSachNguoiThan; }
        set { _danhSachNguoiThan = value; }
    }

    // Methods
    public NhanVienHopDong()
    {
    }

    // "HopDong;HD10;Nguyen Lan Anh;1998;Nguyen Bao, Le Thi Lan; 3.4"
    public NhanVienHopDong(string line)
    {
        string[] ketQuaTachChuoi = line.Split(';');

        string maNhanVien = ketQuaTachChuoi[1];
        string tenNhanVien = ketQuaTachChuoi[2];

        string namSinhStr = ketQuaTachChuoi[3];
        int namSinh = int.Parse(namSinhStr);
        
        string heSoLuongStr = ketQuaTachChuoi[5];
        float heSoLuong = float.Parse(heSoLuongStr);

        string nguoiThanStr = ketQuaTachChuoi[4];
        string[] danhSachNguoiThanArr = nguoiThanStr.Split(',');
        List<string> dsNguoiThan = new List<string>();

        foreach (string nguoiThan in danhSachNguoiThanArr)
        {
            dsNguoiThan.Add(nguoiThan.Trim());
        }

        _maSo = maNhanVien.Trim();
        Ten = tenNhanVien.Trim();
        NamSinh = namSinh;
        HeSoLuong = heSoLuong;

        DanhSachNguoiThan = dsNguoiThan;
    }

    public NhanVienHopDong(string maSo, string hoVaTen, int namSinh, float heSo)
    {
        _maSo = maSo;
        Ten = hoVaTen;
        NamSinh = namSinh;
        HeSoLuong = heSo;
    }

    public override string ToString()
    {
        string str = "Nhan vien hop dong:";
        str += "\n- Ma nhan vien: " + _maSo;
        str += "\n- Ho va ten: " + Ten;
        str += "\n- Nam sinh: " + NamSinh;
        str += "\n- HeSoLuong: " + HeSoLuong;
        str += "\n- Danh sach nguoi than: " + String.Join(", ", DanhSachNguoiThan);

        return str;
    }
}