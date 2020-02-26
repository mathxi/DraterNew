-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3308
-- Généré le :  mer. 26 fév. 2020 à 17:36
-- Version du serveur :  8.0.18
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `drater`
--

-- --------------------------------------------------------

--
-- Structure de la table `classe`
--

DROP TABLE IF EXISTS `classe`;
CREATE TABLE IF NOT EXISTS `classe` (
  `Id` bigint(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(255) NOT NULL,
  `promo` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `classe`
--

INSERT INTO `classe` (`Id`, `Libelle`, `promo`) VALUES
(1, 'B2', '2019-09-02 00:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

DROP TABLE IF EXISTS `eleve`;
CREATE TABLE IF NOT EXISTS `eleve` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `pseudo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `mail` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `mdp` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `IdClasse` bigint(20) NOT NULL,
  `Photo_Profile` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdClasse` (`IdClasse`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`Id`, `pseudo`, `mail`, `mdp`, `IdClasse`, `Photo_Profile`) VALUES
(2, 'math', 'mathnewph@gmail.com', 'math', 1, 'https://picsum.photos/200'),
(4, 'clement', 'clement', 'clement', 1, 'Kernel Power 41.PNG'),
(5, 'clement', 'clement', 'clement', 1, 'Kernel Power 41.PNG');

-- --------------------------------------------------------

--
-- Structure de la table `retard`
--

DROP TABLE IF EXISTS `retard`;
CREATE TABLE IF NOT EXISTS `retard` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `description` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `file` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `idEleve` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idCreateur` (`idEleve`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `retard`
--

INSERT INTO `retard` (`id`, `titre`, `description`, `file`, `idEleve`) VALUES
(4, 'La police m\'arrête, c\'est relou', 'Malheureusement la police m\'arrête c\'est relou, mais bon, c\'est la vie.', 'https://picsum.photos/200', 2),
(17, 'sdqsd', 'qdqsd', 'Kernel Power 41.PNG', 2),
(18, 'Test', 'qsdqsd', '', 5);

-- --------------------------------------------------------

--
-- Structure de la table `tags`
--

DROP TABLE IF EXISTS `tags`;
CREATE TABLE IF NOT EXISTS `tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tags`
--

INSERT INTO `tags` (`id`, `libelle`) VALUES
(1, 'Insolite'),
(2, 'WTF'),
(3, 'Idiot'),
(4, 'Surnaturel'),
(5, 'TestTAg'),
(6, 'qdqsd');

-- --------------------------------------------------------

--
-- Structure de la table `tags_retard`
--

DROP TABLE IF EXISTS `tags_retard`;
CREATE TABLE IF NOT EXISTS `tags_retard` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `idRetard` int(11) NOT NULL,
  `idTags` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tags_retard`
--

INSERT INTO `tags_retard` (`id`, `idRetard`, `idTags`) VALUES
(4, 17, 2),
(5, 18, 4);

-- --------------------------------------------------------

--
-- Structure de la table `vote`
--

DROP TABLE IF EXISTS `vote`;
CREATE TABLE IF NOT EXISTS `vote` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `idEleve` bigint(20) NOT NULL,
  `idRetard` int(11) NOT NULL,
  `dateVote` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `valeur` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idEleve` (`idEleve`) USING BTREE,
  KEY `idRetard` (`idRetard`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `vote`
--

INSERT INTO `vote` (`id`, `idEleve`, `idRetard`, `dateVote`, `valeur`) VALUES
(1, 4, 4, '2020-02-26 18:12:11', 1),
(12, 2, 4, '2020-02-26 18:28:02', 1),
(16, 2, 17, '2020-02-26 18:28:05', 1),
(21, 2, 18, '2020-02-26 18:28:07', -1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `eleve_ibfk_1` FOREIGN KEY (`IdClasse`) REFERENCES `classe` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `retard`
--
ALTER TABLE `retard`
  ADD CONSTRAINT `retard_ibfk_1` FOREIGN KEY (`idEleve`) REFERENCES `eleve` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `vote`
--
ALTER TABLE `vote`
  ADD CONSTRAINT `vote_ibfk_1` FOREIGN KEY (`idRetard`) REFERENCES `retard` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `vote_ibfk_2` FOREIGN KEY (`idEleve`) REFERENCES `eleve` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
