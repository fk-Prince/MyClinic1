-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: clinicdb
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `doctoroperations`
--

DROP TABLE IF EXISTS `doctoroperations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctoroperations` (
  `DoctorID` bigint NOT NULL,
  `OperationCode` bigint NOT NULL,
  PRIMARY KEY (`DoctorID`,`OperationCode`),
  KEY `OperationCode` (`OperationCode`),
  CONSTRAINT `doctoroperations_ibfk_1` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`),
  CONSTRAINT `doctoroperations_ibfk_2` FOREIGN KEY (`OperationCode`) REFERENCES `operations` (`OperationCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctoroperations`
--

LOCK TABLES `doctoroperations` WRITE;
/*!40000 ALTER TABLE `doctoroperations` DISABLE KEYS */;
INSERT INTO `doctoroperations` VALUES (101,1),(102,1),(101,2),(102,2),(101,3);
/*!40000 ALTER TABLE `doctoroperations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctors`
--

DROP TABLE IF EXISTS `doctors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctors` (
  `DoctorID` bigint NOT NULL DEFAULT '1000',
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Age` int NOT NULL,
  `Address` varchar(50) NOT NULL,
  `Gender` varchar(45) NOT NULL,
  `ContactNumber` bigint NOT NULL,
  `Date-Hired` date NOT NULL,
  `PIN` varchar(45) NOT NULL,
  PRIMARY KEY (`DoctorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctors`
--

LOCK TABLES `doctors` WRITE;
/*!40000 ALTER TABLE `doctors` DISABLE KEYS */;
INSERT INTO `doctors` VALUES (100,'Prince','I','Sestoso',20,'Roxas','Male',5345345,'2011-11-12','1234'),(101,'Lebron','Jr','James',54,'LA','Male',543534,'2020-12-12','666'),(102,'Jake','x','Maunas',20,'STI','Male',5435345,'2005-10-10','5454');
/*!40000 ALTER TABLE `doctors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frontdesk`
--

DROP TABLE IF EXISTS `frontdesk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frontdesk` (
  `FrontDeskID` bigint NOT NULL DEFAULT '1000',
  `Username` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `MiddleName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Age` varchar(45) DEFAULT NULL,
  `Type` varchar(45) NOT NULL,
  PRIMARY KEY (`FrontDeskID`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frontdesk`
--

LOCK TABLES `frontdesk` WRITE;
/*!40000 ALTER TABLE `frontdesk` DISABLE KEYS */;
INSERT INTO `frontdesk` VALUES (1,'admin','admin',NULL,NULL,NULL,NULL,'admin');
/*!40000 ALTER TABLE `frontdesk` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operations`
--

DROP TABLE IF EXISTS `operations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operations` (
  `OperationCode` bigint NOT NULL DEFAULT '1',
  `FrontDeskID` bigint NOT NULL,
  `OperationName` varchar(45) NOT NULL,
  `DateAdded` date NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Description` varchar(100) NOT NULL,
  PRIMARY KEY (`OperationCode`,`FrontDeskID`),
  KEY `fk_Operations_FrontDesk1_idx` (`FrontDeskID`),
  CONSTRAINT `fk_Operations_FrontDesk1` FOREIGN KEY (`FrontDeskID`) REFERENCES `frontdesk` (`FrontDeskID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operations`
--

LOCK TABLES `operations` WRITE;
/*!40000 ALTER TABLE `operations` DISABLE KEYS */;
INSERT INTO `operations` VALUES (1,1,'Surgery','2017-07-26',10000.00,'vasdvasedvas'),(2,1,'X-RAY','2012-11-25',2000.00,'asdvbasdvas'),(3,1,'Cosmetic','2013-05-14',1000.00,'vasdvasdv'),(4,1,'Check-UP','2017-05-25',2000.00,'dfgbdfgbdfg'),(5,1,'C','2011-12-25',500.00,'casdcsad');
/*!40000 ALTER TABLE `operations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `PatientID` bigint NOT NULL AUTO_INCREMENT,
  `RoomNo` bigint NOT NULL,
  `FrontDeskID` bigint NOT NULL,
  `DoctorID` bigint NOT NULL,
  `OperationCode` bigint NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Age` varchar(45) NOT NULL,
  `Address` varchar(45) NOT NULL,
  `Gender` varchar(20) NOT NULL,
  `PatientCondition` varchar(100) NOT NULL,
  `BirthDate` date NOT NULL,
  `DateAdmitted` date NOT NULL,
  `ContactNumber` bigint DEFAULT NULL,
  `Bill` decimal(10,2) NOT NULL,
  `DateDischarged` date DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PatientID`,`RoomNo`,`FrontDeskID`,`DoctorID`,`OperationCode`),
  KEY `fk_Patients_Rooms_idx` (`RoomNo`),
  KEY `fk_Patients_FrontDesk1_idx` (`FrontDeskID`),
  KEY `fk_patients_doctoroperations1_idx` (`DoctorID`,`OperationCode`),
  CONSTRAINT `fk_patients_doctoroperations1` FOREIGN KEY (`DoctorID`, `OperationCode`) REFERENCES `doctoroperations` (`DoctorID`, `OperationCode`),
  CONSTRAINT `fk_Patients_FrontDesk1` FOREIGN KEY (`FrontDeskID`) REFERENCES `frontdesk` (`FrontDeskID`),
  CONSTRAINT `fk_Patients_Rooms` FOREIGN KEY (`RoomNo`) REFERENCES `rooms` (`RoomNo`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES (15,401,1,102,2,'34534','345','345','33','34534','Male','dfgdf','2011-11-22','2025-02-28',345345,2000.00,'2025-02-28','Admitted'),(16,402,1,102,2,'234','234','234','234','234','Male','gdf','2011-11-22','2011-11-22',534534,3534.00,NULL,'Admitted'),(17,403,1,102,2,'sdfsd','fsdfs','fsfds','43','asdas','Male','gdfg','2011-11-22','2011-11-22',435345,3435.00,'2025-02-28','Admitted'),(18,404,1,102,2,'vasdvas','dvsadvas','vdasvdas','54','vasdvas','Male','dfg','2011-11-22','2011-11-22',456456,45645.00,'2025-02-28','Admitted');
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `RoomNo` bigint NOT NULL,
  `Occupation` varchar(30) DEFAULT 'Not Occupied',
  PRIMARY KEY (`RoomNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES (401,'Occupied'),(402,'Not Occupied'),(403,'Not Occupied'),(404,'Not Occupied'),(405,'Not Occupied'),(406,'Not Occupied'),(407,'Not Occupied'),(408,'Not Occupied'),(409,'Not Occupied'),(410,'Not Occupied');
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-01  0:07:38
