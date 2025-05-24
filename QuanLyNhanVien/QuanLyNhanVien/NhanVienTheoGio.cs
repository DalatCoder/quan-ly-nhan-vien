namespace QuanLyNhanVien;

public class NhanVienTheoGio : INhanVien
{
    // Fields
    private List<string> _danhSachCongViec = new List<string>();
    private string _maSo;
    private int _namSinh;
    private string _ten;
    private int _tienCongTheoGio;
    
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

    public int TienCongTheoGio
    {
        get { return _tienCongTheoGio; }
        set { _tienCongTheoGio = value; }
    }

    public List<string> DanhSachCongViec
    {
        get { return _danhSachCongViec; }
        set { _danhSachCongViec = value; }
    }
    
    // Methods
    public NhanVienTheoGio()
    {
        
    }

    // TheoGio;TG44;Tran Lan Huong;1991;Truc van phong;4000
    public NhanVienTheoGio(string line)
    {
        string[] ketQuaTachChuoi = line.Split(';');

        string maNhanVien = ketQuaTachChuoi[1];
        string tenNhanVien = ketQuaTachChuoi[2];

        string namSinhStr = ketQuaTachChuoi[3];
        int namSinh = int.Parse(namSinhStr);
        
        string tienCongTheoGioStr = ketQuaTachChuoi[5];
        int tienCongTheoGio = int.Parse(tienCongTheoGioStr);
        
        string danhSachCongViec = ketQuaTachChuoi[4];
        string[] dsCongViecArr = danhSachCongViec.Split(',');
        List<string> dsCongViec = new List<string>();

        foreach (string congViec in dsCongViecArr)
        {
            dsCongViec.Add(congViec.Trim());
        }
        
        _maSo = maNhanVien.Trim();
        Ten = tenNhanVien.Trim();
        NamSinh = namSinh;
        TienCongTheoGio = tienCongTheoGio;
        
        DanhSachCongViec = dsCongViec;
    }

    public NhanVienTheoGio(string maSo, string ten, int namSinh, int tienCong)
    {
        _maSo = maSo;
        Ten = ten;
        NamSinh = namSinh;
        TienCongTheoGio = tienCong;
    }
    
    public override string ToString()
    {
        string str = "Nhan vien theo gio:";
        str += "\n- Ma nhan vien: " + _maSo;
        str += "\n- Ho va ten: " + Ten;
        str += "\n- Nam sinh: " + NamSinh;
        str += "\n- Tien cong theo gio: " + TienCongTheoGio;
        str += "\n- Danh sach cong viec: " + String.Join(", ", DanhSachCongViec);
        
        return str;
    }
}