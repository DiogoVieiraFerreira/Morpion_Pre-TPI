
CREATE  DATABASE IF NOT EXISTS `Morpion` DEFAULT CHARACTER SET utf8 ;
USE `Morpion` ;

-- -----------------------------------------------------
-- Table `Morpion`.`Score`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Morpion`.`Score` (
  `idScore` INT NOT NULL AUTO_INCREMENT,
  `Player01` VARCHAR(45) NOT NULL,
  `Player02` VARCHAR(45) NOT NULL,
  `ScoreP01` INT NOT NULL,
  `ScoreP02` INT NOT NULL,
  PRIMARY KEY (`idScore`));

