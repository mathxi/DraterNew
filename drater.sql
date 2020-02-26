-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3308
-- Généré le :  mer. 26 fév. 2020 à 23:14
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
  `promo` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `classe`
--

INSERT INTO `classe` (`Id`, `Libelle`, `promo`) VALUES
(7, 'B1', '2020-02-26 23:57:17'),
(8, 'B2', '2020-02-26 23:57:21'),
(9, 'B3', '2020-02-26 23:57:26'),
(10, 'I4', '2020-02-26 23:57:39'),
(11, 'I5', '2020-02-26 23:57:50');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

DROP TABLE IF EXISTS `eleve`;
CREATE TABLE IF NOT EXISTS `eleve` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `pseudo` varchar(255) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `mdp` varchar(255) NOT NULL,
  `IdClasse` bigint(20) NOT NULL,
  `Photo_Profile` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdClasse` (`IdClasse`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`Id`, `pseudo`, `mail`, `mdp`, `IdClasse`, `Photo_Profile`) VALUES
(6, 'ClemMor', 'clement.moreau@epsi.fr', 'clement', 9, '');

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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `retard`
--

INSERT INTO `retard` (`id`, `titre`, `description`, `file`, `idEleve`) VALUES
(20, 'Contrôleurs TAN', 'Je voulais prendre le bus a 12h50 pour reprendre les cours a 13h. C\'est en m\'apprêtant à monter dans le busway que je vois les contrôleurs. Je décide de ne pas monter et d\'attendre le prochain tout en disant à mon camarade : \"Je suis sur qu\'ils vont nous attendre au prochain arrêt !\". Pas manqué lorsque l\'on prends le prochain bus il nous attendaient à l\'arrêt suivant. Nous avons donc fini le trajet à pied', 'Kernel Power 41.PNG', 6),
(21, 'Nuit blanche ASP', 'Afin de finir le magnifique projet ASP.NET que notre admirable professeur ( mais également notre Dieu ) nous à confié, nous avons effectués quelques nuits blanches consécutives et la fatigue nous clou au lit. ', 'Kernel Power 41.PNG', 6);

-- --------------------------------------------------------

--
-- Structure de la table `tags`
--

DROP TABLE IF EXISTS `tags`;
CREATE TABLE IF NOT EXISTS `tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tags`
--

INSERT INTO `tags` (`id`, `libelle`) VALUES
(1, 'Insolite'),
(2, 'WTF'),
(3, 'Idiot'),
(4, 'Surnaturel'),
(7, 'Karma');

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tags_retard`
--

INSERT INTO `tags_retard` (`id`, `idRetard`, `idTags`) VALUES
(8, 20, 1),
(9, 21, 7);

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
  `valeur` int(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idEleve` (`idEleve`) USING BTREE,
  KEY `idRetard` (`idRetard`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `vote`
--

INSERT INTO `vote` (`id`, `idEleve`, `idRetard`, `dateVote`, `valeur`) VALUES
(66, 6, 21, '2020-02-27 00:12:56', 1),
(67, 6, 20, '2020-02-27 00:12:57', -1);

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
