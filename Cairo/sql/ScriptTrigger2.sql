DROP TRIGGER IF EXISTS TR_ATUALIZA_NOMES_CERTIFICADO_INSERT;
DROP TRIGGER IF EXISTS TR_ATUALIZA_NOMES_CERTIFICADO_UPDATE;
DELIMITER //
CREATE TRIGGER TR_ATUALIZA_NOMES_CERTIFICADO_INSERT AFTER INSERT ON CERTIFICADO
FOR EACH ROW
BEGIN
	DECLARE NOME_ALUNO_VAR VARCHAR(100);
    DECLARE NOME_DISCIPLINA_VAR VARCHAR (100);
    
    -- PREENCHER NOME DO ALUNO
    SELECT NOME_ALUNO
      INTO NOME_ALUNO_VAR
      FROM MATRICULA
     WHERE ID = NEW.ID_MATRICULA;
     
     UPDATE CERTIFICADO
        SET NOME_ALUNO = NOME_ALUNO_VAR
	  WHERE ID = NEW.ID;
      
	-- PREENCHER NOME DA DISCIPLINA
    SELECT NOME_DISCIPLINA
      INTO NOME_DISCIPLINA_VAR
      FROM MATRICULA
     WHERE ID = NEW.ID_MATRICULA;
     
     UPDATE CERTIFICADO
        SET NOME_DISCIPLINA = NOME_DISCIPLINA_VAR
	  WHERE ID = NEW.ID;
END //
DELIMITER ;


DELIMITER //
CREATE TRIGGER TR_ATUALIZA_NOMES_CERTIFICADO_UPDATE AFTER UPDATE ON CERTIFICADO
FOR EACH ROW
BEGIN
	DECLARE NOME_ALUNO_VAR VARCHAR(100);
    DECLARE NOME_DISCIPLINA_VAR VARCHAR (100);
    
    -- PREENCHER NOME DO ALUNO
    SELECT NOME_ALUNO
      INTO NOME_ALUNO_VAR
      FROM MATRICULA
     WHERE ID = NEW.ID_MATRICULA;
     
     UPDATE CERTIFICADO
        SET NOME_ALUNO = NOME_ALUNO_VAR
	  WHERE ID = NEW.ID;
      
	-- PREENCHER NOME DA DISCIPLINA
    SELECT NOME_DISCIPLINA
      INTO NOME_DISCIPLINA_VAR
      FROM MATRICULA
     WHERE ID = NEW.ID_MATRICULA;
     
     UPDATE CERTIFICADO
        SET NOME_DISCIPLINA = NOME_DISCIPLINA_VAR
	  WHERE ID = NEW.ID;
END //
DELIMITER ;