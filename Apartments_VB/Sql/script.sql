
-- Database: apartmentmanagement
-- Clean and Synced Version (2025-07-14)
Create database apartmentmanagement;
USE apartmentmanagement;
-- =============================
-- Drop existing tables (nếu cần)
-- =============================
DROP TABLE IF EXISTS `maintenancerequest`, `apartmentresident`, `resident`, `user`, `role`, `apartment`, `apartmenttype`;

-- =============================
-- Table: apartmenttype
-- =============================
CREATE TABLE `apartmenttype` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(255),
  UNIQUE (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `apartmenttype` (`Id`, `Name`, `Description`) VALUES
(1,'Chung cư mini','Dành cho sinh viên'),
(2,'Chung cư trung cấp','Phù hợp gia đình trẻ'),
(3,'Chung cư cao cấp','Đầy đủ tiện nghi'),
(4,'Penthouse','Căn hộ cao cấp trên tầng thượng');

-- =============================
-- Table: apartment
-- =============================
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
(1,1,'Mini A','Q1, TP.HCM',5,NOW(),1000000000.00),
(2,1,'Mini B','Q3, TP.HCM',4,NOW(),950000000.00),
(3,2,'Mid A','Q7, TP.HCM',12,NOW(),1800000000.00),
(4,2,'Mid B','Q10, TP.HCM',14,NOW(),2000000000.00),
(5,2,'Mid C','Tân Bình, TP.HCM',10,NOW(),1700000000.00),
(6,3,'High A','Q5, TP.HCM',20,NOW(),3200000000.00),
(7,3,'High B','Bình Thạnh',18,NOW(),2900000000.00),
(8,3,'High C','Thủ Đức',15,NOW(),3000000000.00),
(9,4,'Pent A','Tầng 25, Landmark',1,NOW(),8000000000.00),
(10,4,'Pent B','Tầng 30, Bitexco',1,NOW(),8500000000.00);

-- =============================
-- Table: role
-- =============================
CREATE TABLE `role` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(50) NOT NULL,
  `Description` VARCHAR(255),
  UNIQUE (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `role` VALUES
(1,'Admin','Quản trị hệ thống'),
(2,'User','Nhân viên quản lý');

-- =============================
-- Table: user
-- =============================
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

-- =============================
-- Table: resident
-- =============================
CREATE TABLE `resident` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `FullName` VARCHAR(100) NOT NULL,
  `Phone` VARCHAR(20),
  `Email` VARCHAR(100),
  `DateOfBirth` DATE,
  `Gender` BIT NOT NULL COMMENT '1 = Nam, 0 = Nữ',
  `IsActive` BIT NOT NULL DEFAULT b'1',
  `CreatedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `resident` (`FullName`, `Phone`, `Email`, `DateOfBirth`, `Gender`) VALUES
('Nguyễn Văn A', '0901111111', 'vana@example.com', '1990-01-01', 1),
('Trần Thị B', '0902222222', 'thib@example.com', '1992-02-02', 0),
('Lê Văn C', '0903333333', 'vanc@example.com', '1985-03-03', 1),
('Phạm Thị D', '0904444444', 'thid@example.com', '1991-04-04', 0),
('Hoàng Văn E', '0905555555', 'vane@example.com', '1995-05-05', 1),
('Võ Thị F', '0906666666', 'thif@example.com', '1993-06-06', 0),
('Đỗ Văn G', '0907777777', 'vang@example.com', '1988-07-07', 1),
('Ngô Thị H', '0908888888', 'thih@example.com', '1996-08-08', 0),
('Bùi Văn I', '0909999999', 'vani@example.com', '1990-09-09', 1),
('Lương Thị J', '0910000000', 'thij@example.com', '1994-10-10', 0);

-- =============================
-- Table: apartmentresident
-- =============================
CREATE TABLE `apartmentresident` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `ResidentId` INT NOT NULL,
  `ApartmentId` INT NOT NULL,
  `StartDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `EndDate` DATETIME DEFAULT NULL,
  `Note` TEXT,
  FOREIGN KEY (`ResidentId`) REFERENCES `resident`(`Id`),
  FOREIGN KEY (`ApartmentId`) REFERENCES `apartment`(`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `apartmentresident` (`ResidentId`, `ApartmentId`, `StartDate`, `EndDate`, `Note`) VALUES
(1, 1, '2023-01-01', NULL, NULL),
(2, 1, '2023-01-01', NULL, NULL),
(3, 2, '2022-06-15', '2023-07-01', 'Chuyển đi'),
(3, 3, '2023-07-01', NULL, NULL),
(4, 4, '2023-03-20', NULL, NULL),
(5, 5, '2022-11-01', NULL, NULL),
(6, 6, '2023-05-10', NULL, NULL),
(7, 7, '2023-02-01', NULL, NULL),
(8, 8, '2023-04-01', NULL, NULL),
(9, 9, '2023-01-01', NULL, NULL);

-- =============================
-- Table: maintenancerequest
-- =============================
CREATE TABLE `maintenancerequest` (
  `Id` INT AUTO_INCREMENT PRIMARY KEY,
  `ApartmentId` INT NOT NULL,
  `RequestDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Description` TEXT NOT NULL,
  `Status` INT NOT NULL DEFAULT 1,
  FOREIGN KEY (`ApartmentId`) REFERENCES `apartment`(`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `maintenancerequest` (`ApartmentId`, `RequestDate`, `Description`, `Status`) VALUES
(1, '2024-01-10', 'Rò rỉ ống nước bếp', 1),
(2, '2024-01-12', 'Máy lạnh không hoạt động', 2),
(3, '2024-01-15', 'Đèn phòng khách chập chờn', 3),
(4, '2024-01-20', 'Sàn nhà bong tróc', 1),
(5, '2024-01-25', 'Nứt tường nhà vệ sinh', 2),
(6, '2024-02-01', 'Hư ổ điện phòng ngủ', 3),
(7, '2024-02-05', 'Cửa sổ không đóng được', 1),
(8, '2024-02-10', 'Máy hút mùi hư', 2),
(9, '2024-02-15', 'Mùi lạ trong phòng tắm', 3),
(10, '2024-02-20', 'Bình nóng lạnh không nóng', 1);
