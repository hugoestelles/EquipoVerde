-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.24-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para nutriwise
CREATE DATABASE IF NOT EXISTS `nutriwise` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `nutriwise`;

-- Volcando estructura para tabla nutriwise.alimentos
CREATE TABLE IF NOT EXISTS `alimentos` (
  `idAlimento` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `valorNutricio` decimal(2,0) NOT NULL,
  PRIMARY KEY (`idAlimento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.alimentos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla nutriwise.aliplato
CREATE TABLE IF NOT EXISTS `aliplato` (
  `idAlimentos` int(11) NOT NULL,
  `idPlatos` int(11) NOT NULL,
  PRIMARY KEY (`idAlimentos`,`idPlatos`),
  KEY `idPlatos` (`idPlatos`),
  CONSTRAINT `aliplato_ibfk_1` FOREIGN KEY (`idAlimentos`) REFERENCES `alimentos` (`idAlimento`),
  CONSTRAINT `aliplato_ibfk_2` FOREIGN KEY (`idPlatos`) REFERENCES `platos` (`idPlato`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.aliplato: ~0 rows (aproximadamente)

-- Volcando estructura para tabla nutriwise.dietas
CREATE TABLE IF NOT EXISTS `dietas` (
  `idDieta` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `objetivoUsu` int(11) NOT NULL,
  `tipoDieta` varchar(50) DEFAULT NULL,
  `numPlatos` int(11) DEFAULT NULL,
  `numIngredientes` int(11) DEFAULT NULL,
  PRIMARY KEY (`idDieta`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.dietas: ~0 rows (aproximadamente)
INSERT INTO `dietas` (`idDieta`, `nombre`, `objetivoUsu`, `tipoDieta`, `numPlatos`, `numIngredientes`) VALUES
	(1, 'Bajo En Calorias', 1, 'Vegana', 23, 89);

-- Volcando estructura para tabla nutriwise.donativos
CREATE TABLE IF NOT EXISTS `donativos` (
  `idDonativo` int(11) NOT NULL AUTO_INCREMENT,
  `cantidad` decimal(2,0) NOT NULL,
  `fechaDonativo` datetime NOT NULL,
  `idUsuari` int(11) NOT NULL,
  PRIMARY KEY (`idDonativo`),
  KEY `idUsuari` (`idUsuari`),
  CONSTRAINT `donativos_ibfk_1` FOREIGN KEY (`idUsuari`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.donativos: ~2 rows (aproximadamente)
INSERT INTO `donativos` (`idDonativo`, `cantidad`, `fechaDonativo`, `idUsuari`) VALUES
	(3, 23, '2023-05-10 19:55:06', 1),
	(4, 45, '2023-05-10 20:03:22', 1),
	(5, 99, '2023-05-12 17:19:51', 1);

-- Volcando estructura para tabla nutriwise.objetivo
CREATE TABLE IF NOT EXISTS `objetivo` (
  `objetivoUsuario` int(11) NOT NULL,
  `objetivoDieta` int(11) NOT NULL,
  PRIMARY KEY (`objetivoUsuario`,`objetivoDieta`),
  KEY `objetivoDieta` (`objetivoDieta`),
  CONSTRAINT `objetivo_ibfk_1` FOREIGN KEY (`objetivoUsuario`) REFERENCES `usuario` (`idUsuario`),
  CONSTRAINT `objetivo_ibfk_2` FOREIGN KEY (`objetivoDieta`) REFERENCES `dietas` (`idDieta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.objetivo: ~0 rows (aproximadamente)

-- Volcando estructura para tabla nutriwise.platodieta
CREATE TABLE IF NOT EXISTS `platodieta` (
  `idPlatos` int(11) NOT NULL,
  `idDietas` int(11) NOT NULL,
  PRIMARY KEY (`idPlatos`,`idDietas`),
  KEY `idDietas` (`idDietas`),
  CONSTRAINT `platodieta_ibfk_1` FOREIGN KEY (`idPlatos`) REFERENCES `platos` (`idPlato`),
  CONSTRAINT `platodieta_ibfk_2` FOREIGN KEY (`idDietas`) REFERENCES `dietas` (`idDieta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.platodieta: ~0 rows (aproximadamente)

-- Volcando estructura para tabla nutriwise.platos
CREATE TABLE IF NOT EXISTS `platos` (
  `idPlato` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  PRIMARY KEY (`idPlato`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.platos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla nutriwise.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `correo` varchar(40) NOT NULL,
  `clave` varchar(20) NOT NULL,
  `nombre` varchar(40) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `altura` decimal(2,0) NOT NULL,
  `peso` decimal(2,0) NOT NULL,
  `tipoIntolencia` int(11) NOT NULL,
  `cantActividad` int(11) NOT NULL,
  `objetivo` int(11) NOT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.usuario: ~1 rows (aproximadamente)
INSERT INTO `usuario` (`idUsuario`, `correo`, `clave`, `nombre`, `apellidos`, `altura`, `peso`, `tipoIntolencia`, `cantActividad`, `objetivo`) VALUES
	(1, 'barikelop@gmail.com', '1234', 'ruben', 'miras', 99, 34, 0, 23, 2);

-- Volcando estructura para tabla nutriwise.valoraciones
CREATE TABLE IF NOT EXISTS `valoraciones` (
  `idValoracion` int(11) NOT NULL AUTO_INCREMENT,
  `numEstrellas` int(11) NOT NULL,
  `fechaValoracion` datetime NOT NULL,
  `comentario` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idValoracion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla nutriwise.valoraciones: ~0 rows (aproximadamente)
INSERT INTO `valoraciones` (`idValoracion`, `numEstrellas`, `fechaValoracion`, `comentario`) VALUES
	(1, 3, '2023-05-10 19:43:30', 'hola xd'),
	(2, 4, '2023-05-12 17:07:04', 'JAJAJAJAJA HOLA GUAPOS');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
