-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 10, 2024 at 07:23 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quizfy`
--

-- --------------------------------------------------------

--
-- Table structure for table `auth`
--

CREATE TABLE `auth` (
  `USERNAME` varchar(256) NOT NULL,
  `PASSWORD` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `auth`
--

INSERT INTO `auth` (`USERNAME`, `PASSWORD`) VALUES
('pass', 'pass');

-- --------------------------------------------------------

--
-- Table structure for table `demo_ans`
--

CREATE TABLE `demo_ans` (
  `USERNAME` varchar(256) NOT NULL,
  `Q1` int(11) NOT NULL,
  `Q2` int(11) NOT NULL,
  `Q3` int(11) NOT NULL,
  `Q4` int(11) NOT NULL,
  `Q5` int(11) NOT NULL,
  `TOTAL` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `demo_ans`
--

INSERT INTO `demo_ans` (`USERNAME`, `Q1`, `Q2`, `Q3`, `Q4`, `Q5`, `TOTAL`) VALUES
('pass', 1, 1, 1, 1, 1, 5);

-- --------------------------------------------------------

--
-- Table structure for table `demo_que`
--

CREATE TABLE `demo_que` (
  `QNO` int(11) NOT NULL,
  `Q` varchar(1024) NOT NULL,
  `A1` varchar(256) NOT NULL,
  `A2` varchar(256) NOT NULL,
  `A3` varchar(256) NOT NULL,
  `A4` varchar(256) NOT NULL,
  `CR_ANS` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `demo_que`
--

INSERT INTO `demo_que` (`QNO`, `Q`, `A1`, `A2`, `A3`, `A4`, `CR_ANS`) VALUES
(0, '5', '25', '20', '', '', ''),
(1, 'What is the syntax to declare a variable in C?', 'A. int x', 'B. variable x', 'C. x = int', 'D. x int', 'A'),
(2, 'Which of the following is NOT a valid C data type?', 'A. int', 'B. char', 'C. float', 'D. string', 'D'),
(3, 'What is the output of the following code?      printf(\"%d\", sizeof(int))', 'A. 4', 'B. 2', 'C.8', 'D. Compiler dependent', 'A'),
(1, 'What is the syntax to declare a variable in C?', 'A. int x', 'B. variable x', 'C. x = int', 'D. x int', 'A'),
(2, 'Which of the following is NOT a valid C data type?', 'A. int', 'B. char', 'C. float', 'D. string', 'D'),
(3, 'What is the output of the following code?      printf(\"%d\", sizeof(int))', 'A. 4', 'B. 2', 'C.8', 'D. Compiler dependent', 'A'),
(4, 'What is the correct syntax for the for loop in C?', 'A. for (i = 0; i < n; i++)', 'B. for i = 0; i < n; i++', 'C. for i = 0 to n', 'D. for (i = 0; i < n)', 'A'),
(5, 'Which symbol is used for single line comments in C?', 'A. //', 'B. /*', 'C. #', 'D. NO SYMBOL', 'A');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
