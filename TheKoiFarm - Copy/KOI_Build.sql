-- Create table KhachHang
CREATE TABLE KhachHang (
    KhachHangID NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    NgayDangKy DATE
);

-- Create table DuAnThiCong
CREATE TABLE DuAnThiCong (
    DuAnID NVARCHAR(50) PRIMARY KEY,
    KhachHangID NVARCHAR(50),
    TenDuAn NVARCHAR(100),
    NgayBatDau DATE,
    NgayHoanThanhDuKien DATE,
    TrangThai NVARCHAR(50),
    DiaDiem NVARCHAR(255),
    TongChiPhi DECIMAL(18,2),
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);

-- Create table TienDoThiCong
CREATE TABLE TienDoThiCong (
    TienDoID NVARCHAR(50) PRIMARY KEY,
    DuAnID NVARCHAR(50),
    NgayCapNhat DATE,
    MoTa NVARCHAR(255),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);

-- Create table VatLieu
CREATE TABLE VatLieu (
    VatLieuID NVARCHAR(50) PRIMARY KEY,
    TenVatLieu NVARCHAR(100),
    DonViTinh NVARCHAR(50),
    GiaDonVi DECIMAL(18,2)
);

-- Create table VatLieuSuDung
CREATE TABLE VatLieuSuDung (
    SuDungID NVARCHAR(50) PRIMARY KEY,
    DuAnID NVARCHAR(50),
    VatLieuID NVARCHAR(50),
    SoLuong DECIMAL(18,2),
    ThanhTien DECIMAL(18,2),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID),
    FOREIGN KEY (VatLieuID) REFERENCES VatLieu(VatLieuID)
);

-- Create table NhanVien
CREATE TABLE NhanVien (
    NhanVienID NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100),
    ViTri NVARCHAR(50),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100)
);

-- Create table NhanVienThamGia
CREATE TABLE NhanVienThamGia (
    ThamGiaID NVARCHAR(50) PRIMARY KEY,
    DuAnID NVARCHAR(50),
    NhanVienID NVARCHAR(50),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);

-- Create table ThanhToan
CREATE TABLE ThanhToan (
    ThanhToanID NVARCHAR(50) PRIMARY KEY,
    DuAnID NVARCHAR(50),
    NgayThanhToan DATE,
    SoTien DECIMAL(18,2),
    HinhThucThanhToan NVARCHAR(50),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);

-- Create table TaiKhoanKhachHang
CREATE TABLE TaiKhoanKhachHang (
    TaiKhoanID NVARCHAR(50) PRIMARY KEY,
    KhachHangID NVARCHAR(50),
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(255), 
    NgayTao DATE,
    TrangThai NVARCHAR(50),
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);

-- Insert materials for koi pond construction into VatLieu table
INSERT INTO VatLieu (VatLieuID, TenVatLieu, DonViTinh, GiaDonVi)
VALUES
    ('VL001', 'Cement', 'kg', 5000),
    ('VL002', 'Sand', 'kg', 1000),
    ('VL003', 'Gravel', 'kg', 2000),
    ('VL004', 'Waterproofing Compound', 'liter', 15000),
    ('VL005', 'Reinforcement Bars', 'kg', 12000),
    ('VL006', 'Pond Liner', 'sq_meter', 35000),
    ('VL007', 'Filter Media', 'unit', 50000),
    ('VL008', 'PVC Pipe', 'meter', 1500),
    ('VL009', 'Pump', 'unit', 200000),
    ('VL010', 'Rocks and Pebbles', 'kg', 3000);


INSERT INTO NhanVien (NhanVienID, HoTen, ViTri, SoDienThoai, Email)
VALUES 
    ('NV001', 'Nguyen Van A', 'Engineer', '0912345670', 'nguyenvana@example.com'),
    ('NV002', 'Tran Thi B', 'Project Manager', '0912345671', 'tranthib@example.com'),
    ('NV003', 'Le Van C', 'Architect', '0912345672', 'levanc@example.com'),
    ('NV004', 'Pham Thi D', 'Construction Worker', '0912345673', 'phamthid@example.com'),
    ('NV005', 'Hoang Van E', 'Electrician', '0912345674', 'hoangvane@example.com'),
    ('NV006', 'Do Thi F', 'Plumber', '0912345675', 'dothif@example.com'),
    ('NV007', 'Vu Van G', 'Site Supervisor', '0912345676', 'vuvang@example.com'),
    ('NV008', 'Phan Thi H', 'Safety Officer', '0912345677', 'phanthih@example.com'),
    ('NV009', 'Ngo Van I', 'Mechanic', '0912345678', 'ngovani@example.com'),
    ('NV010', 'Bui Thi J', 'Quality Control', '0912345679', 'buithij@example.com');
