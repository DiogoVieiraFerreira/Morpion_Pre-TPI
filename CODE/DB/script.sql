-- -----------------------------------------------------
-- Table `Score`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS Score (
  	idScore INTEGER PRIMARY KEY,
	Player01 VARCHAR(45) NOT NULL,
	Player02 VARCHAR(45) NOT NULL,
	ScoreP01 INT NOT NULL,
	ScoreP02 INT NOT NULL
);

