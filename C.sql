-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: clinicdatabase
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
-- Table structure for table `clinicoperation_tbl`
--

DROP TABLE IF EXISTS `clinicoperation_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clinicoperation_tbl` (
  `OperationID` bigint NOT NULL AUTO_INCREMENT,
  `FrontDeskID` bigint DEFAULT NULL,
  `OperationName` varchar(45) NOT NULL,
  `Date-Added` date NOT NULL,
  `OperationDescription` varchar(45) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`OperationID`),
  UNIQUE KEY `ServiceName_UNIQUE` (`OperationName`),
  KEY `FrontDeskID_idx` (`FrontDeskID`),
  CONSTRAINT `FrontDeskID` FOREIGN KEY (`FrontDeskID`) REFERENCES `frontdesk_tbl` (`FrontDeskID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=123146 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clinicoperation_tbl`
--

LOCK TABLES `clinicoperation_tbl` WRITE;
/*!40000 ALTER TABLE `clinicoperation_tbl` DISABLE KEYS */;
INSERT INTO `clinicoperation_tbl` VALUES (543,2,'345','2015-05-11','dfgdfbgdfgndfgndfgdfgvdfgdgndfgndfgndfgn',5000.00),(2001,2,'5345','2015-05-11','adas',1000.00),(2342,2,'456','2015-05-11','45645n6546b45',4554.00),(3345,1,'3453','2025-02-27','345',345.00),(12312,1,'fgh','2015-05-11','dgbdfgbdfg',54545.00),(12313,1,'34545645','2025-02-27','345',345.00),(12314,1,'vdas','2025-02-27','43',4343.00),(12315,1,'53456','2025-02-27','515112312',51.00),(12316,1,'54','2025-02-27','43',54.00),(12317,1,'545454','2025-02-27','54',54.00);
/*!40000 ALTER TABLE `clinicoperation_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctor_tbl`
--

DROP TABLE IF EXISTS `doctor_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctor_tbl` (
  `DoctorID` bigint NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Age` int NOT NULL,
  `Date-Hired` date NOT NULL,
  `Password` varchar(45) NOT NULL,
  `OperationID` bigint DEFAULT NULL,
  PRIMARY KEY (`DoctorID`),
  KEY `fk_Doctor_tbl_ClinicPersonel_tbl_idx` (`DoctorID`),
  KEY `OperationID_idx` (`OperationID`),
  CONSTRAINT `OperationID` FOREIGN KEY (`OperationID`) REFERENCES `clinicoperation_tbl` (`OperationID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctor_tbl`
--

LOCK TABLES `doctor_tbl` WRITE;
/*!40000 ALTER TABLE `doctor_tbl` DISABLE KEYS */;
INSERT INTO `doctor_tbl` VALUES (100,'asd','asd','asdas',43,'2001-11-11','100',2001);
/*!40000 ALTER TABLE `doctor_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frontdesk_tbl`
--

DROP TABLE IF EXISTS `frontdesk_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frontdesk_tbl` (
  `FrontDeskID` bigint NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `MiddleName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Age` int DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FrontDeskID`),
  KEY `fk_Staff_tbl_ClinicPersonel_tbl1_idx` (`FrontDeskID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frontdesk_tbl`
--

LOCK TABLES `frontdesk_tbl` WRITE;
/*!40000 ALTER TABLE `frontdesk_tbl` DISABLE KEYS */;
INSERT INTO `frontdesk_tbl` VALUES (1,'admin','admin','asd','asd','asd',54,'Admin'),(2,'sa','sa','sa','sas','sa',25,'Staff');
/*!40000 ALTER TABLE `frontdesk_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient_tbl`
--

DROP TABLE IF EXISTS `patient_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient_tbl` (
  `PatientID` bigint NOT NULL AUTO_INCREMENT,
  `FrontDeskID` bigint NOT NULL,
  `DoctorID` bigint NOT NULL,
  `OperationID` bigint NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Age` int NOT NULL,
  `DateAdmitted` date NOT NULL,
  `Address` varchar(45) NOT NULL,
  `PatientCondition` varchar(45) DEFAULT NULL,
  `MedicalHistory` varchar(45) DEFAULT NULL,
  `Bill` decimal(10,2) NOT NULL,
  `Gender` varchar(45) NOT NULL,
  `ContactNumber` int DEFAULT NULL,
  `BirthDate` date NOT NULL,
  PRIMARY KEY (`PatientID`),
  KEY `OperationID_idx` (`OperationID`),
  KEY `DoctorID_idx` (`DoctorID`),
  KEY `FrontDeskID_idx` (`FrontDeskID`),
  CONSTRAINT `Patient_Doctor->ID` FOREIGN KEY (`DoctorID`) REFERENCES `doctor_tbl` (`DoctorID`),
  CONSTRAINT `Patient_FrontDesk->ID` FOREIGN KEY (`FrontDeskID`) REFERENCES `frontdesk_tbl` (`FrontDeskID`) ON UPDATE CASCADE,
  CONSTRAINT `Patient_Operation->ID` FOREIGN KEY (`OperationID`) REFERENCES `clinicoperation_tbl` (`OperationID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5007 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient_tbl`
--

LOCK TABLES `patient_tbl` WRITE;
/*!40000 ALTER TABLE `patient_tbl` DISABLE KEYS */;
INSERT INTO `patient_tbl` VALUES (5001,1,100,2001,'dfg','34534','345',45,'2001-01-10','345','345','345',1000.00,'Male',354,'2001-01-10'),(5002,1,100,2001,'sdf','sdf','234',1020,'2001-01-10','sdfsd','sdfs','asd',1000.00,'Male',5345,'2001-01-10'),(5003,1,100,2001,'asd','acsd','ascd',54,'2025-02-27','asdcas','sdfsdv','sdvfsvdfsd',1000.00,'Male',456456,'2015-05-05'),(5004,1,100,2001,'345','345','345',43,'2025-02-27','3453453','456','456',1000.00,'Male',456456,'2001-11-11'),(5005,1,100,2001,'asd','asd','asd',43,'2025-02-27','ses','sdf','sdf',1000.00,'Male',3453,'2001-11-21'),(5006,1,100,2001,'asdva','vsad','dvas',43,'2025-02-27','vasdv','','',1000.00,'Male',345345,'2001-11-21');
/*!40000 ALTER TABLE `patient_tbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-27 19:59:34
