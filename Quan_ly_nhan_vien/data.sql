Select * from a
Select * from TblBangLuongCTy
Select * from TblBangCongThuViec
Select * from TblBoPhan
Select * from TblCongKhoiDieuHanh
Select * from TblCongKhoiVanChuyen
Select * from TblCongKhoiVanPHong
Select * from TblHoSoThuViec
Select * from TblNVThoiViec
Select * from TblPhongBan
Select * from TblSoBH
Select * from TblTangLuong
Select * from TblTTCaNhan
Select * from TblTTNVCoBan
Select * from TblThaiSan
Select * from tbuser

Select * from tbuser
where Username='hien2' and Pass='hien2'


CREATE PROC USP_Login
@userName nvarchar(50), @passWord nvarchar(50), @quyen nchar(10)
AS
BEGIN
	SELECT * FROM dbo.tbuser WHERE UserName = @username AND Pass = @passWord AND Quyen =@quyen
END
GO


EXEC dbo.USP_Login @userName = N'hien2' ,@passWord=N'hien2',@quyen=N'Admin' 

INSERT INTO tbuser
    (Username, Pass, Quyen, Ten, Ngaysinh)
VALUES
    ('hien2', 'hien2', 'Admin', 'hiep', '1997-07-12');

	INSERT INTO tbuser
    (Username, Pass, Quyen, Ten, Ngaysinh)
VALUES
    ('hien2', 'hien2', 'Admin', 'hien', '1997-07-12');
	
	INSERT INTO tbuser
    (Username, Pass, Quyen, Ten, Ngaysinh)
VALUES
    ('aa', 'aa', 'User', 'user', '1997-07-12');
	-- xoá
	delete from tbuser
where Username='1234';


-- sửa thông tin
CREATE PROC USP_Login_Change
@userName nvarchar(50), @passWord nvarchar(50), @quyen nchar(10),@ten nvarchar(50),@ngaysinh
AS
BEGIN
		
END
GO
EXEC dbo.USP_Login @userName = N'hien2' ,@passWord=N'hien2',@quyen=N'Admin' 


-- thông tin cá nhân 
UPDATE TblTTCaNhan
		SET MaNV = '001' ,HoTen=N'Nguyễn Đình Hiệp', NoiSinh = N'Gia lai' , NguyenQuan = N'Viêt nam',
		DCThuongChu =N'Phạm văn Đồng',DCTamChu=N'Bình lợi',SDT='09876543',DanToc=N'kinh',TonGiao=N'khong',
		QuocTich=N'viẹt nam',HocVan=N'Thạc sĩ',GhiChu=N'đẹp zai'

	where MaNV='001'

	delete from TblTTCaNhan
where MaNV='1234';


--Account

-- Thêm
declare @dem int
set @dem = (select  count(*) from tbuser
group by Username
having Username = 'hiep10')
if @dem >0
	print 'Đã có tài khoản này'
else 
	insert into tbuser values ('clone','clone','Admin','ten','2000-10-10')

select * from tbuser
-- xoá account
delete from tbuser where Username ='hiep10'

-- sửa account

update tbuser 
set Username ='hiep10' ,Pass ='pass1',Quyen='User' , Ten ='hiep',Ngaysinh ='2001-10-10'
where Username ='clone'

-- cá nhân

select * from TblTTCaNhan

-- thêm
declare @dem int
set @dem = (select  count(*) from TblTTCaNhan
group by MaNV
having MaNV = '022')
if @dem >0
	print 'Đã có tài khoản này'
else 
insert into TblTTCaNhan values 
('022','tentaolao','sao hoa','haosao','mat trang','trang mat',9847123223,'toc','khong','VN','khong co','trong') 

--xoá
delete from TblTTCaNhan where HoTen='tentaolao'

-- sửa thông tin

update TblTTCaNhan 
set MaNV ='001' ,HoTen ='nguyen dinh hiep2',NoiSinh='gia lai' , NguyenQuan ='Dong nai',DCThuongChu ='dong van phma'
,DCTamChu ='binh loi',SDT =143234234,DanToc='toc',TonGiao='khong',QuocTich ='Viet nam', HocVan ='giao su',GhiChu='so1'
where MaNV ='001'


-- thong tin co ban
select * from TblTTNVCoBan

-- thêm
declare @dem int
set @dem = (select  count(*) from TblTTNVCoBan
group by MaNV
having MaNV = '022')
if @dem >0
	print 'Đã có tài khoản này'
else 
insert into TblTTNVCoBan values 
('mb01','kt01','023','Lê văn tham','ml3','1990-04-12','Nam','rồi','123412341',N'Gia Lai',N'Nhân viên','Kinh tế','24 tháng','2019-10-10','2020-10-10',N'ghi chus') 

--xoá
delete from TblTTCaNhan where MaNV='022'

-- sửa thông tin

update TblTTCaNhan 
set MaNV ='001' ,HoTen ='nguyen dinh hiep2',NoiSinh='gia lai' , NguyenQuan ='Dong nai',DCThuongChu ='dong van phma'
,DCTamChu ='binh loi',SDT =143234234,DanToc='toc',TonGiao='khong',QuocTich ='Viet nam', HocVan ='giao su',GhiChu='so1'
where MaNV ='001'

-- account

-- kiem tra khi them acc
declare @dem int
set @dem = (select  count(*) from tbuser
group by Username
having Username = 'acc2')
if @dem >0
	print N'Đã có tài khoản này'
else 
insert into tbuser values ('acc2','pass1','User','Name','1999-04-03')


update tbuser 
set Username ='acc', Pass='so1'
where Ngaysinh='1997-07-12'

-- xoá tai khoản


select * from tbuser