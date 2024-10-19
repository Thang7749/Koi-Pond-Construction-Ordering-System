create table KhachHang
(
	KhachHangID INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    NgayDangKy DATE
);

CREATE TABLE DuAnThiCong 
(
    DuAnID INT PRIMARY KEY,
    KhachHangID INT,
    TenDuAn NVARCHAR(100),
    NgayBatDau DATE,
    NgayHoanThanhDuKien DATE,
    TrangThai NVARCHAR(50),
    DiaDiem NVARCHAR(255),
    TongChiPhi DECIMAL(18,2),
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);


CREATE TABLE TienDoThiCong (
    TienDoID INT PRIMARY KEY,
    DuAnID INT,
    NgayCapNhat DATE,
    MoTa NVARCHAR(255),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);


CREATE TABLE VatLieu (
    VatLieuID INT PRIMARY KEY,
    TenVatLieu NVARCHAR(100),
    DonViTinh NVARCHAR(50),
    GiaDonVi DECIMAL(18,2)
);


CREATE TABLE VatLieuSuDung (
    SuDungID INT PRIMARY KEY,
    DuAnID INT,
    VatLieuID INT,
    SoLuong DECIMAL(18,2),
    ThanhTien DECIMAL(18,2),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID),
    FOREIGN KEY (VatLieuID) REFERENCES VatLieu(VatLieuID)
);



CREATE TABLE NhanVien (
    NhanVienID INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    ViTri NVARCHAR(50),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100)
);


CREATE TABLE NhanVienThamGia (
    ThamGiaID INT PRIMARY KEY ,
    DuAnID INT,
    NhanVienID INT,
    NgayBatDau DATE,
    NgayKetThuc DATE,
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);


CREATE TABLE ThanhToan (
    ThanhToanID INT PRIMARY KEY ,
    DuAnID INT,
    NgayThanhToan DATE,
    SoTien DECIMAL(18,2),
    HinhThucThanhToan NVARCHAR(50),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);
