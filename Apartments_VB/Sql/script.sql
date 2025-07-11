-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: apartmentmanagement
-- ------------------------------------------------------
-- Server version	5.7.44-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `apartment`
--

DROP TABLE IF EXISTS `apartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apartment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ApartmentTypeId` int(11) NOT NULL,
  `ApartmentName` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `FloorCount` int(11) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Price` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`Id`),
  KEY `ApartmentTypeId` (`ApartmentTypeId`),
  CONSTRAINT `apartment_ibfk_1` FOREIGN KEY (`ApartmentTypeId`) REFERENCES `apartmenttype` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apartment`
--

LOCK TABLES `apartment` WRITE;
/*!40000 ALTER TABLE `apartment` DISABLE KEYS */;
INSERT INTO `apartment` VALUES (1,1,'Hô Hô','Nguyễn Hữu Thọ, Quận 7, TP.HCM',25,'2025-05-27 18:59:27',3200000000.00),(3,2,'Saigonres','188 Nguyễn Xí, Bình Thạnh, TP.HCM',20,'2025-05-27 18:59:27',2500000.00),(4,2,'Him Lam Chợ Lớn','Quận 6, TP.HCM',22,'2025-05-27 18:59:27',2800000000.00),(5,3,'Ehome 3','Đường Hồ Học Lãm, Bình Tân, HCM',12,'2025-05-27 18:59:27',1800000000.00),(6,3,'Carina','Quận 8, TP.HCM',15,'2025-05-27 18:59:27',1900000000.00),(7,4,'Mini Home Trường Chinh','Trường Chinh, Tân Bình, TP.HCM',5,'2025-05-27 18:59:27',900000000.00),(8,4,'Mini Apartment Lý Thường Kiệt','Lý Thường Kiệt, Q.10, TP.HCM',4,'2025-05-27 18:59:27',950000000.00),(31,69,'Căn hộ test','HN 1',5,'2025-06-18 14:42:57',6666.00),(32,40,'Chung cư 70','HN,VN',10,'2025-07-10 21:52:57',200000.00),(33,40,'Chung Cư 8/11','Khánh Hà, Hà Nội',6,'2025-07-10 21:53:23',300000.00),(34,40,'Chưng cư 9/11','HNN',3,'2025-07-11 09:59:54',30000.00);
/*!40000 ALTER TABLE `apartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `apartmenttype`
--

DROP TABLE IF EXISTS `apartmenttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `apartmenttype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UQ_ApartmentType_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apartmenttype`
--

LOCK TABLES `apartmenttype` WRITE;
/*!40000 ALTER TABLE `apartmenttype` DISABLE KEYS */;
INSERT INTO `apartmenttype` VALUES (1,'Căn hộ 123','Mô tả hehe'),(2,'Chung cư trung cấp','Cơ bản, phù hợp với gia đình nhỏ'),(3,'Chung cư giá rẻ','Chi phí thấp, tiện ích hạn chế'),(4,'Chung cư mini 2','Dành cho người độc thân hoặc sinh viên'),(36,'Loai ABCD','string'),(39,'Chung cư sập xệ','Mô tả'),(40,'1-bedroom apartment','An apartment with one bedroom and living area.'),(41,'2-bedroom apartment','Spacious apartment with two bedrooms.'),(42,'Studio apartment','Compact apartment with open-plan layout.'),(43,'Penthouse','Luxury apartment on the top floor.'),(44,'Duplex apartment','Apartment with two levels connected by stairs.'),(45,'Loại 66','Mô tả nhé'),(60,'Chung cư trung cấp 1','heheheh'),(68,'Chung cư trung cấp 3',NULL),(69,'Chung cư giá',NULL),(71,'Chung cư trung cấp 44',NULL);
/*!40000 ALTER TABLE `apartmenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maintenancerequest`
--

DROP TABLE IF EXISTS `maintenancerequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `maintenancerequest` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ApartmentId` int(11) NOT NULL,
  `RequestDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Description` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `Status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `ApartmentId` (`ApartmentId`),
  CONSTRAINT `maintenancerequest_ibfk_1` FOREIGN KEY (`ApartmentId`) REFERENCES `apartment` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maintenancerequest`
--

LOCK TABLES `maintenancerequest` WRITE;
/*!40000 ALTER TABLE `maintenancerequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `maintenancerequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UQ_Role_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Admin','Quản trị viên hệ thống'),(2,'User','Nhân viên hệ thống');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) CHARACTER SET utf8 NOT NULL,
  `PasswordHash` varchar(255) CHARACTER SET utf8 NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `IsActive` bit(1) NOT NULL DEFAULT b'1',
  `RoleId` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UQ_User_Username` (`Username`),
  KEY `RoleId` (`RoleId`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin.user','adminpass','Nguyen Van Admin',_binary '',1),(2,'normal.user','userpass','Tran Thi Binh Thuong',_binary '',2);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-11 14:48:01
