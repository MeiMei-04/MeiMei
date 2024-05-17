CREATE DATABASE QLCAFEMEIMEI
USE QLCAFEMEIMEI
CREATE TABLE NhanVien(
    id int  IDENTITY(1,1) PRIMARY key,
    hoten NVARCHAR(100) not null,
    chucvu nvarchar(50) not null,
    tendangnhap varchar(50) not null,
    matkhau varchar(100) not null,
    cccd varchar(12) not null,
    trangthai int not null
);
CREATE TABLE Calam(
    id int  IDENTITY(1,1) PRIMARY key,
    id_nv int not null,
    ngaylamviec DATE not null,
    giobatdau TIME NOT NULL,
    gioketthuc TIME NOT NULL,
    trangthai int not null
    FOREIGN KEY (id_nv) REFERENCES NhanVien(id)
)
CREATE TABLE ThucDon(
    id int  IDENTITY(1,1) PRIMARY key,
    tenmon nvarchar(100) not null,
    danhmuc nvarchar(100) not null,
    gia int not null,
    trangthai int not null
)
CREATE TABLE HoaDon(
    id int  IDENTITY(1,1) PRIMARY key,
    tenban nvarchar(100) not null,
    id_nv int not null,
    ngaytao date DEFAULT GETDATE(),
    ngaythanhtoan date null,
    tongtien int DEFAULT 0,
    trangthai int not null
    FOREIGN KEY (id_nv) REFERENCES NhanVien(id)
)
CREATE TABLE ChiTietHoaDon(
    id int  IDENTITY(1,1) PRIMARY key,
    id_hd int not null,
    id_td int not null,
    soluong int not null,
    dongia int not null,
    trangthai int not null
    FOREIGN KEY (id_hd) REFERENCES HoaDon(id),
    FOREIGN KEY (id_td) REFERENCES ThucDon(id)
)
-- Chèn dữ liệu vào bảng NhanVien (Bảng Nhân viên)
INSERT INTO NhanVien (hoten, chucvu, tendangnhap, matkhau, cccd, trangthai)
VALUES 
    (N'Em Hiếu Phục Vụ', N'Nhân Viên', 'dhieu', '1', '123456789', 1),
    (N'Alice Johnson', N'Quản lý', 'alice', 'manager123', '456789123', 1);

-- Chèn dữ liệu vào bảng Calam (Bảng Ca làm)
INSERT INTO Calam (id_nv, ngaylamviec, giobatdau, gioketthuc, trangthai)
VALUES 
    (1, '2024-05-16', '08:00:00', '16:00:00', 1),
    (2, '2024-05-16', '10:00:00', '18:00:00', 1);

-- Chèn dữ liệu vào bảng ThucDon (Bảng Thực đơn)
INSERT INTO ThucDon (tenmon, danhmuc, gia, trangthai)
VALUES 
    (N'Espresso', N'Cà phê', 50, 1),
    (N'Capuccino', N'Cà phê', 60, 1),
    (N'Chicken Burger', N'Món ăn', 100, 1),
    (N'Caesar Salad', N'Món ăn', 80, 1);

-- Chèn dữ liệu vào bảng HoaDon (Bảng Hóa đơn)
INSERT INTO HoaDon (tenban, id_nv, tongtien, trangthai)
VALUES 
    (N'Bàn 1', 1, 0, 1),
    (N'Bàn 2', 2, 0, 1);

-- Chèn dữ liệu vào bảng ChiTietHoaDon (Bảng Chi tiết hóa đơn)
INSERT INTO ChiTietHoaDon (id_hd, id_td, soluong, dongia, trangthai)
VALUES 
    (1, 1, 2, 50, 1), -- 2 Espresso
    (1, 3, 1, 100, 1), -- 1 Chicken Burger
    (2, 2, 3, 60, 1); -- 3 Cappuccino
Select * from ThucDon where trangthai = 1