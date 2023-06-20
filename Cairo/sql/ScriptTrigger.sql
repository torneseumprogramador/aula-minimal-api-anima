DROP TRIGGER IF EXISTS TR_ATUALIZA_NOMES_INSERT;
DROP TRIGGER IF EXISTS TR_ATUALIZA_NOMES_UPDATE;


DELIMITER //
CREATE TRIGGER TR_ATUALIZA_NOMES_INSERT BEFORE INSERT ON MATRICULA
FOR EACH ROW
BEGIN
	DECLARE NOME_ALUNO_VAR VARCHAR(100);
    DECLARE NOME_DISCIPLINA_VAR VARCHAR (100);
    
    -- PREENCHER NOME DO ALUNO
    SELECT NOME
      INTO NOME_ALUNO_VAR
      FROM ALUNO
     WHERE ID = NEW.ID_ALUNO;
     
     UPDATE MATRICULA
        SET NOME_ALUNO = NOME_ALUNO_VAR
	  WHERE ID = NEW.ID;
      
	-- PREENCHER NOME DA DISCIPLINA
    SELECT NOME_DISCIPLINA
      INTO NOME_DISCIPLINA_VAR
      FROM DISCIPLINA
     WHERE ID = NEW.ID_DISCIPLINA;
     
     UPDATE MATRICULA
        SET NOME_DISCIPLINA = NOME_DISCIPLINA_VAR
	  WHERE ID = NEW.ID;
END //
DELIMITER ;


DELIMITER //
CREATE TRIGGER TR_ATUALIZA_NOMES_UPDATE BEFORE UPDATE ON MATRICULA
FOR EACH ROW
BEGIN
	DECLARE NOME_ALUNO_VAR VARCHAR(100);
    DECLARE NOME_DISCIPLINA_VAR VARCHAR (100);
    
    -- PREENCHER NOME DO ALUNO
    SELECT NOME
      INTO NOME_ALUNO_VAR
      FROM ALUNO
     WHERE ID = NEW.ID_ALUNO;
     
     UPDATE MATRICULA
        SET NOME_ALUNO = NOME_ALUNO_VAR
	  WHERE ID = NEW.ID;
      
	-- PREENCHER NOME DA DISCIPLINA
    SELECT NOME_DISCIPLINA
      INTO NOME_DISCIPLINA_VAR
      FROM DISCIPLINA
     WHERE ID = NEW.ID_DISCIPLINA;
     
     UPDATE MATRICULA
        SET NOME_DISCIPLINA = NOME_DISCIPLINA_VAR
	  WHERE ID = NEW.ID;
END //
DELIMITER ;