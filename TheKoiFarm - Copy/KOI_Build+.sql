CREATE TABLE DanhGia (
  DanhGiaID NVARCHAR(50) PRIMARY KEY,
  KhachHangID NVARCHAR(50),
  DuAnID NVARCHAR(50),
  DiemDanhGia INT CHECK (DiemDanhGia BETWEEN 1 AND 5),
  NgayDanhGia DATE,
  FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID),
  FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);

CREATE TABLE NhanXet (
  NhanXetID NVARCHAR(50) PRIMARY KEY,
  KhachHangID NVARCHAR(50),
  DuAnID NVARCHAR(50),
  NoiDung NVARCHAR(1000),
  NgayPhanHoi DATE,
  FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID),
  FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);

CREATE TABLE HoaDon (
  HoaDonID NVARCHAR(50) PRIMARY KEY,
  KhachHangID NVARCHAR(50),
  NgayLap DATE,
  TongTien DECIMAL(18,2),
  TrangThai NVARCHAR(50),
  FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);

CREATE TABLE ChiTietHoaDon (
  ChiTietID NVARCHAR(50) PRIMARY KEY,
  HoaDonID NVARCHAR(50),
  DuAnID NVARCHAR(50),
  SoTien DECIMAL(18,2),
  FOREIGN KEY (HoaDonID) REFERENCES HoaDon(HoaDonID),
  FOREIGN KEY (DuAnID) REFERENCES DuAnThiCong(DuAnID)
);

INSERT INTO DanhGia (DanhGiaID, KhachHangID, DuAnID, DiemDanhGia, NgayDanhGia)
VALUES
  ('R001', 'KH001', 'DA001', 5, '2024-10-15'),
  ('R002', 'KH002', 'DA002', 4, '2024-10-16'),
  ('R003', 'KH003', 'DA003', 3, '2024-10-17');

INSERT INTO NhanXet (NhanXetID, KhachHangID, DuAnID, NoiDung, NgayPhanHoi)
VALUES
  ('FB001', 'KH001', 'DA001', 'Dự án hoàn thành xuất sắc!', '2024-10-20'),
  ('FB002', 'KH002', 'DA002', 'Công việc hoàn thành đúng tiến độ.', '2024-10-21'),
  ('FB003', 'KH003', 'DA003', 'Chất lượng công trình rất tốt.', '2024-10-22');

INSERT INTO HoaDon (HoaDonID, KhachHangID, NgayLap, TongTien, TrangThai)
VALUES
  ('HD001', 'KH001', '2024-10-25', 50000000, 'Đã thanh toán'),
  ('HD002', 'KH002', '2024-10-26', 100000000, 'Chưa thanh toán'),
  ('HD003', 'KH003', '2024-10-27', 150000000, 'Đã thanh toán');

INSERT INTO ChiTietHoaDon (ChiTietID, HoaDonID, DuAnID, SoTien)
VALUES
  ('CTHD001', 'HD001', 'DA001', 20000000),
  ('CTHD002', 'HD001', 'DA001', 30000000),
  ('CTHD003', 'HD002', 'DA002', 100000000),
  ('CTHD004', 'HD003', 'DA003', 50000000),
  ('CTHD005', 'HD003', 'DA003', 100000000);
