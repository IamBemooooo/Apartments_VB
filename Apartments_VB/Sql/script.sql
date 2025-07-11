-- Database: apartmentmanagement
-- Simplified and Clean Version (2025-07-11)

-- Drop existing tables
DROP TABLE IF EXISTS `maintenancerequest`, `apartment`, `apartmenttype`, `user`, `role`;

-- ================================
-- Table: apartmenttype
-- ================================
CREATE TABLE `apartmenttype` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(255),
  UNIQUE (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `apartmenttype` (`Id`, `Name`, `Description`) VALUES
(1,'Căn hộ 123','Mô tả hehe'),
(2,'Chung cư trung cấp','Cơ bản, phù hợp với gia đình nhỏ'),
(3,'Chung cư giá rẻ','Chi phí thấp, tiện ích hạn chế'),
(4,'Chung cư mini 2','Dành cho người độc thân hoặc sinh viên'),
(36,'Loai ABCD','string'),
(39,'Chung cư sập xệ','Mô tả'),
(40,'1-bedroom apartment','An apartment with one bedroom and living area.'),
(41,'2-bedroom apartment','Spacious apartment with two bedrooms.'),
(42,'Studio apartment','Compact apartment with open-plan layout.'),
(43,'Penthouse','Luxury apartment on the top floor.'),
(44,'Duplex apartment','Apartment with two levels connected by stairs.'),
(45,'Loại 66','Mô tả nhé'),
(60,'Chung cư trung cấp 1','heheheh'),
(68,'Chung cư trung cấp 3',NULL),
(69,'Chung cư giá',NULL),
(71,'Chung cư trung cấp 44',NULL);

-- ================================
-- Table: apartment
-- ================================
CREATE TABLE `apartment` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `ApartmentTypeId` INT NOT NULL,
  `ApartmentName` VARCHAR(150),
  `Address` VARCHAR(255) NOT NULL,
  `FloorCount` INT,
  `CreatedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Price` DECIMAL(18,2) NOT NULL DEFAULT 0.00,
  FOREIGN KEY (`ApartmentTypeId`) REFERENCES `apartmenttype`(`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `apartment` VALUES
(1,1,'Hô Hô','Nguyễn Hữu Thọ, Quận 7, TP.HCM',25,'2025-05-27 18:59:27',3200000000.00),
(3,2,'Saigonres','188 Nguyễn Xí, Bình Thạnh, TP.HCM',20,'2025-05-27 18:59:27',2500000.00),
(4,2,'Him Lam Chợ Lớn','Quận 6, TP.HCM',22,'2025-05-27 18:59:27',2800000000.00),
(5,3,'Ehome 3','Đường Hồ Học Lãm, Bình Tân, HCM',12,'2025-05-27 18:59:27',1800000000.00),
(6,3,'Carina','Quận 8, TP.HCM',15,'2025-05-27 18:59:27',1900000000.00),
(7,4,'Mini Home Trường Chinh','Trường Chinh, Tân Bình, TP.HCM',5,'2025-05-27 18:59:27',900000000.00),
(8,4,'Mini Apartment Lý Thường Kiệt','Lý Thường Kiệt, Q.10, TP.HCM',4,'2025-05-27 18:59:27',950000000.00),
(31,69,'Căn hộ test','HN 1',5,'2025-06-18 14:42:57',6666.00),
(32,40,'Chung cư 70','HN,VN',10,'2025-07-10 21:52:57',200000.00),
(33,40,'Chung Cư 8/11','Khánh Hà, Hà Nội',6,'2025-07-10 21:53:23',300000.00),
(34,40,'Chưng cư 9/11','HNN',3,'2025-07-11 09:59:54',30000.00);

-- ================================
-- Table: role
-- ================================
CREATE TABLE `role` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(50) NOT NULL,
  `Description` VARCHAR(255),
  UNIQUE (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `role` VALUES
(1,'Admin','Quản trị viên hệ thống'),
(2,'User','Nhân viên hệ thống');

-- ================================
-- Table: user
-- ================================
CREATE TABLE `user` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `Username` VARCHAR(50) NOT NULL,
  `PasswordHash` VARCHAR(255) NOT NULL,
  `FullName` VARCHAR(100),
  `IsActive` BIT NOT NULL DEFAULT b'1',
  `RoleId` INT NOT NULL,
  FOREIGN KEY (`RoleId`) REFERENCES `role`(`Id`),
  UNIQUE (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `user` VALUES
(1,'admin.user','adminpass','Nguyen Van Admin',b'1',1),
(2,'normal.user','userpass','Tran Thi Binh Thuong',b'1',2);

-- ================================
-- Table: maintenancerequest
-- ================================
CREATE TABLE `maintenancerequest` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `ApartmentId` INT NOT NULL,
  `RequestDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Description` TEXT NOT NULL,
  `Status` INT NOT NULL DEFAULT 1,
  FOREIGN KEY (`ApartmentId`) REFERENCES `apartment`(`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- (Chưa có dữ liệu mẫu cho maintenancerequest)
