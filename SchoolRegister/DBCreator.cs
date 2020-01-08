using System;

namespace SchoolRegister
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    public class DBCreator
    {
        private static MySqlConnection sqlConnection;
        private static MySqlDataReader dataReader;
        private static MySqlCommand command;
        public DBCreator(MySqlConnection connection, MySqlDataReader reader, MySqlCommand com)
        {
            sqlConnection = connection;
            dataReader = reader;
            command = com;
            if (!dataReader.IsClosed)
            {
                dataReader.Close();
            }
        }


        void setHeadmaster()
        {
            throw new NotImplementedException();
        }

        void setExampleCategories()
        {
            throw new NotImplementedException();
        }

        void DeleteOldBase()
        {
            command.CommandText = $"EXEC sp_msforeachtable \"ALTER TABLE ? NOCHECK CONSTRAINT all\"";
            dataReader = command.ExecuteReader();
        }

        void CreateNewBase()
        {
            try
            {
                command.CommandText = "CREATE TABLE dane_osobowe(  pesel NUMBER(11) NOT NULL,  imie VARCHAR2(20) NOT NULL,  nazwisko VARCHAR2(50) NOT NULL,  adres_zamieszkania VARCHAR2(100),  numer_telefonu NUMBER(9),  email  VARCHAR2(50))";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE dane_osobowe ADD CONSTRAINT dane_osobowe_pk PRIMARY KEY ( pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE jednostka (godzina NUMBER(2) NOT NULL,  minuta  NUMBER(2) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE jednostka ADD CONSTRAINT jednostka_pk PRIMARY KEY ( godzina,minuta ) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE kategoria_oceny(  nazwa VARCHAR2(20) NOT NULL,  waga  NUMBER(1) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE kategoria_oceny ADD CONSTRAINT kategoria_oceny_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE klasa (rocznik NUMBER(4) NOT NULL,literka VARCHAR2(1) NOT NULL, nauczyciel_dane_osobowe_pesel NUMBER(11),  profil_nazwa VARCHAR2(50) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa ADD CONSTRAINT klasa_pk PRIMARY KEY ( rocznik, literka ) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE lekcja (  dzien_tygodnia NUMBER(1) NOT NULL,jednostka_godzina  NUMBER(2) NOT NULL,jednostka_minuta NUMBER(2) NOT NULL,klasa_rocznik  NUMBER(4) NOT NULL,klasa_literka  VARCHAR2(1) NOT NULL,sala_pietro  NUMBER(1) NOT NULL,sala_numer NUMBER(2) NOT NULL,przedmiot_nazwa_przedmiotu VARCHAR2(20) NOT NULL) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_pk PRIMARY KEY(klasa_rocznik, jednostka_godzina, jednostka_minuta, dzien_tygodnia, klasa_literka)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE nauczyciel (  etat NUMBER(3, 2) NOT NULL,dane_osobowe_pesel NUMBER(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE nauczyciel ADD CONSTRAINT nauczyciel_pk PRIMARY KEY ( dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE obecnosc (  data DATE NOT NULL,uczen_pesel  NUMBER(11) NOT NULL, lekcja_dzien_tygodnia  NUMBER(1) NOT NULL,lekcja_jednostka_godzina NUMBER(2) NOT NULL,lekcja_jednostka_minuta  NUMBER(2) NOT NULL,lekcja_klasa_rocznik NUMBER(4) NOT NULL,lekcja_klasa_literka VARCHAR2(1) NOT NULL,status_nazwa VARCHAR2(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_pk PRIMARY KEY(data,uczen_pesel,lekcja_jednostka_godzina,lekcja_jednostka_minuta,lekcja_dzien_tygodnia) ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE ocena (  id INTEGER NOT NULL,ocena NUMBER(1) NOT NULL,data  DATE NOT NULL,  opis VARCHAR2(300) NOT NULL,kategoria_oceny_nazwa VARCHAR2(20) NOT NULL,przedmiot_nazwa_przedmiotu  VARCHAR2(20) NOT NULL,uczen_dane_osobowe_pesel  NUMBER(11) NOT NULL,nauczyciel_dane_osobowe_pesel NUMBER(11) NOT NULL); ";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena ADD CONSTRAINT ocena_pk PRIMARY KEY ( id )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE opieka (  uczen_pesel NUMBER(11) NOT NULL,opiekun_pesel NUMBER(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka ADD CONSTRAINT relation_35_pk PRIMARY KEY ( uczen_pesel, opiekun_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE opiekun (  dochod NUMBER(10, 2) NOT NULL,  pesel  NUMBER(11) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opiekun ADD CONSTRAINT opiekun_pk PRIMARY KEY ( pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE profil ADD CONSTRAINT profil_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE przedmiot (  nazwa_przedmiotu VARCHAR2(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE przedmiot ADD CONSTRAINT przedmiot_pk PRIMARY KEY ( nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE sala (  pietro NUMBER(1) NOT NULL,numer NUMBER(2) NOT NULL,liczba_miejsc NUMBER(2) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE sala ADD CONSTRAINT sala_pk PRIMARY KEY ( numer,  pietro )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE status (  nazwa VARCHAR2(20) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE status ADD CONSTRAINT status_pk PRIMARY KEY ( nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE uczen (  dane_osobowe_pesel NUMBER(11) NOT NULL,  klasa_rocznik  NUMBER(4) NOT NULL,  nr_w_dzienniku NUMBER(2) NOT NULL,  klasa_literka  VARCHAR2(1) NOT NULL)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen ADD CONSTRAINT uczen_pk PRIMARY KEY(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE TABLE uwaga (  id INTEGER NOT NULL,tresc VARCHAR2(300) NOT NULL,puntky_do_zachowania  NUMBER(2),  uczen_dane_osobowe_pesel NUMBER(11) NOT NULL,nauczyciel_dane_osobowe_pesel NUMBER(11) NOT NULL,data  DATE)";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga ADD CONSTRAINT uwaga_pk PRIMARY KEY ( id )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa  ADD CONSTRAINT klasa_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE klasa  ADD CONSTRAINT klasa_profil_fk FOREIGN KEY(profil_nazwa)  REFERENCES profil(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_jednostka_fk FOREIGN KEY(jednostka_godzina,   jednostka_minuta)  REFERENCES jednostka(godzina,  minuta )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_klasa_fk FOREIGN KEY(klasa_rocznik,   klasa_literka)  REFERENCES klasa(rocznik, literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_przedmiot_fk FOREIGN KEY(przedmiot_nazwa_przedmiotu)  REFERENCES przedmiot(nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE lekcja  ADD CONSTRAINT lekcja_sala_fk FOREIGN KEY(sala_numer,  sala_pietro)  REFERENCES sala(numer,  pietro )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE nauczyciel  ADD CONSTRAINT nauczyciel_dane_osobowe_fk FOREIGN KEY(dane_osobowe_pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_lekcja_fk FOREIGN KEY(lekcja_klasa_rocznik,  lekcja_jednostka_godzina,  lekcja_jednostka_minuta,  lekcja_dzien_tygodnia,  lekcja_klasa_literka)  REFERENCES lekcja(klasa_rocznik,  jednostka_godzina,  jednostka_minuta,  dzien_tygodnia,  klasa_literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_status_fk FOREIGN KEY(status_nazwa)  REFERENCES status(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE obecnosc  ADD CONSTRAINT obecnosc_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_kategoria_oceny_fk FOREIGN KEY(kategoria_oceny_nazwa)  REFERENCES kategoria_oceny(nazwa )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_przedmiot_fk FOREIGN KEY(przedmiot_nazwa_przedmiotu)  REFERENCES przedmiot(nazwa_przedmiotu )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE ocena  ADD CONSTRAINT ocena_uczen_fk FOREIGN KEY(uczen_dane_osobowe_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opiekun  ADD CONSTRAINT opiekun_dane_osobowe_fk FOREIGN KEY(pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_opiekun_fk FOREIGN KEY(opiekun_pesel)  REFERENCES opiekun(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE opieka  ADD CONSTRAINT relation_35_uczen_fk FOREIGN KEY(uczen_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen  ADD CONSTRAINT uczen_dane_osobowe_fk FOREIGN KEY(dane_osobowe_pesel)  REFERENCES dane_osobowe(pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uczen  ADD CONSTRAINT uczen_klasa_fk FOREIGN KEY(klasa_rocznik,  klasa_literka)  REFERENCES klasa(rocznik, literka )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga  ADD CONSTRAINT uwaga_nauczyciel_fk FOREIGN KEY(nauczyciel_dane_osobowe_pesel)  REFERENCES nauczyciel(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "ALTER TABLE uwaga  ADD CONSTRAINT uwaga_uczen_fk FOREIGN KEY(uczen_dane_osobowe_pesel)  REFERENCES uczen(dane_osobowe_pesel )";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE SEQUENCE ocenaSeq AS BIGINT START WITH 1 INCREMENT BY 1";
                dataReader = command.ExecuteReader();
                dataReader.Close();

                command.CommandText = "CREATE SEQUENCE uwagaSeq AS BIGINT START WITH 1 INCREMENT BY 1";
                dataReader = command.ExecuteReader();
                dataReader.Close();
            }
            catch (MySqlException)
            {
                Console.WriteLine("Couldn't create a db");
                DeleteOldBase();
            }
        }


    }
}
