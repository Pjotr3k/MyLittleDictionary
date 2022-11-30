-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 25 Lis 2022, 14:59
-- Wersja serwera: 10.4.25-MariaDB
-- Wersja PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `my_little_dict`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `definitions`
--

CREATE TABLE `definitions` (
  `idDef` int(11) NOT NULL,
  `primeEntryId` int(11) DEFAULT NULL,
  `descr` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `definitions`
--

INSERT INTO `definitions` (`idDef`, `primeEntryId`, `descr`) VALUES
(4, NULL, 'to write'),
(5, NULL, 'woman'),
(6, NULL, 'sand');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `entries`
--

CREATE TABLE `entries` (
  `idEntry` int(11) NOT NULL,
  `idLang` int(11) NOT NULL,
  `idPos` int(11) NOT NULL,
  `code` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `entries`
--

INSERT INTO `entries` (`idEntry`, `idLang`, `idPos`, `code`) VALUES
(28, 1, 2, '1.2.scrībō'),
(29, 5, 2, '5.2.ktab'),
(30, 2, 1, '2.1.wahine'),
(31, 1, 1, '1.1.femina'),
(32, 1, 1, '1.1.arēna');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `entry_def_connect`
--

CREATE TABLE `entry_def_connect` (
  `idEntry` int(11) NOT NULL,
  `idDef` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `entry_def_connect`
--

INSERT INTO `entry_def_connect` (`idEntry`, `idDef`) VALUES
(28, 4),
(29, 4),
(30, 5),
(31, 5),
(32, 6);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `forms`
--

CREATE TABLE `forms` (
  `idForm` int(11) NOT NULL,
  `idLanguage` int(11) NOT NULL,
  `idPos` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `isLemma` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `forms`
--

INSERT INTO `forms` (`idForm`, `idLanguage`, `idPos`, `name`, `isLemma`) VALUES
(1, 1, 1, 'nom. sg', b'1'),
(2, 1, 2, '1sg. praesens', b'1'),
(3, 1, 2, 'Infinitivum', b'0'),
(4, 1, 1, 'gen. sg.', b'0'),
(5, 5, 2, '3m past', b'1'),
(8, 1, 3, 'nom. sg. masc. ', b'1'),
(9, 1, 3, 'nom. sg. fem. ', b'0'),
(10, 1, 3, 'nom. sg. neut.', b'0'),
(11, 1, 3, 'nom. pl. masc.', b'0'),
(12, 1, 3, 'nom. pl. fem.', b'0'),
(13, 1, 1, 'perf. act.', b'0'),
(14, 1, 2, 'supine', b'0'),
(15, 1, 2, 'perf. act.', b'0'),
(17, 2, 2, 'active', b'1'),
(18, 2, 2, 'passive', b'0'),
(19, 5, 2, 'pres. particip.', b'0'),
(20, 5, 2, 'past particip.', b'0'),
(21, 2, 1, 'singular', b'1'),
(22, 2, 1, 'plural', b'0');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `languages`
--

CREATE TABLE `languages` (
  `idLanguage` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `languages`
--

INSERT INTO `languages` (`idLanguage`, `name`) VALUES
(1, 'Latin'),
(2, 'Māori'),
(3, 'Prūsiska'),
(4, 'Gutarazda'),
(5, 'Sūryāyā');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `parts_of_speech`
--

CREATE TABLE `parts_of_speech` (
  `idPos` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `parts_of_speech`
--

INSERT INTO `parts_of_speech` (`idPos`, `name`) VALUES
(1, 'Noun'),
(2, 'Verb'),
(3, 'Adjective'),
(4, 'Adposition');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `words`
--

CREATE TABLE `words` (
  `idWord` int(11) NOT NULL,
  `idEntry` int(11) NOT NULL,
  `idForm` int(11) NOT NULL,
  `word` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `words`
--

INSERT INTO `words` (`idWord`, `idEntry`, `idForm`, `word`) VALUES
(8, 28, 2, 'scrībō'),
(9, 29, 5, 'ktab'),
(10, 30, 21, 'wahine'),
(11, 31, 1, 'femina'),
(12, 32, 1, 'arēna'),
(13, 28, 3, 'scrībere');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `definitions`
--
ALTER TABLE `definitions`
  ADD PRIMARY KEY (`idDef`),
  ADD KEY `primeEntryId` (`primeEntryId`);

--
-- Indeksy dla tabeli `entries`
--
ALTER TABLE `entries`
  ADD PRIMARY KEY (`idEntry`),
  ADD KEY `idLang` (`idLang`),
  ADD KEY `idPos` (`idPos`);

--
-- Indeksy dla tabeli `entry_def_connect`
--
ALTER TABLE `entry_def_connect`
  ADD PRIMARY KEY (`idEntry`,`idDef`),
  ADD KEY `idDef` (`idDef`);

--
-- Indeksy dla tabeli `forms`
--
ALTER TABLE `forms`
  ADD PRIMARY KEY (`idForm`),
  ADD KEY `idLanguage` (`idLanguage`),
  ADD KEY `idPos` (`idPos`);

--
-- Indeksy dla tabeli `languages`
--
ALTER TABLE `languages`
  ADD PRIMARY KEY (`idLanguage`);

--
-- Indeksy dla tabeli `parts_of_speech`
--
ALTER TABLE `parts_of_speech`
  ADD PRIMARY KEY (`idPos`);

--
-- Indeksy dla tabeli `words`
--
ALTER TABLE `words`
  ADD PRIMARY KEY (`idWord`),
  ADD KEY `idEntry` (`idEntry`),
  ADD KEY `idForm` (`idForm`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `definitions`
--
ALTER TABLE `definitions`
  MODIFY `idDef` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `entries`
--
ALTER TABLE `entries`
  MODIFY `idEntry` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT dla tabeli `forms`
--
ALTER TABLE `forms`
  MODIFY `idForm` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT dla tabeli `languages`
--
ALTER TABLE `languages`
  MODIFY `idLanguage` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `parts_of_speech`
--
ALTER TABLE `parts_of_speech`
  MODIFY `idPos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `words`
--
ALTER TABLE `words`
  MODIFY `idWord` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `definitions`
--
ALTER TABLE `definitions`
  ADD CONSTRAINT `definitions_ibfk_1` FOREIGN KEY (`primeEntryId`) REFERENCES `entries` (`idEntry`);

--
-- Ograniczenia dla tabeli `entries`
--
ALTER TABLE `entries`
  ADD CONSTRAINT `entries_ibfk_1` FOREIGN KEY (`idLang`) REFERENCES `languages` (`IdLanguage`),
  ADD CONSTRAINT `entries_ibfk_2` FOREIGN KEY (`idPos`) REFERENCES `parts_of_speech` (`idPos`);

--
-- Ograniczenia dla tabeli `entry_def_connect`
--
ALTER TABLE `entry_def_connect`
  ADD CONSTRAINT `entry_def_connect_ibfk_1` FOREIGN KEY (`idEntry`) REFERENCES `entries` (`idEntry`),
  ADD CONSTRAINT `entry_def_connect_ibfk_2` FOREIGN KEY (`idDef`) REFERENCES `definitions` (`idDef`);

--
-- Ograniczenia dla tabeli `forms`
--
ALTER TABLE `forms`
  ADD CONSTRAINT `forms_ibfk_1` FOREIGN KEY (`idLanguage`) REFERENCES `languages` (`IdLanguage`),
  ADD CONSTRAINT `forms_ibfk_2` FOREIGN KEY (`idPos`) REFERENCES `parts_of_speech` (`idPos`);

--
-- Ograniczenia dla tabeli `words`
--
ALTER TABLE `words`
  ADD CONSTRAINT `words_ibfk_1` FOREIGN KEY (`idEntry`) REFERENCES `entries` (`idEntry`),
  ADD CONSTRAINT `words_ibfk_2` FOREIGN KEY (`idForm`) REFERENCES `forms` (`idForm`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
