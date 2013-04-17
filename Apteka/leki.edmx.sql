
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/17/2013 19:45:08
-- Generated from EDMX file: C:\Users\Andre\Documents\GitHub\apteka\Apteka\leki.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_leki];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__t_CartIte__Produ__59FA5E80]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_CartItems] DROP CONSTRAINT [FK__t_CartIte__Produ__59FA5E80];
GO
IF OBJECT_ID(N'[dbo].[FK_sub_id_num]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_sklad] DROP CONSTRAINT [FK_sub_id_num];
GO
IF OBJECT_ID(N'[dbo].[FK_t_informacje_t_inter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_informacje] DROP CONSTRAINT [FK_t_informacje_t_inter];
GO
IF OBJECT_ID(N'[dbo].[FK_t_informacje_t_leki]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_informacje] DROP CONSTRAINT [FK_t_informacje_t_leki];
GO
IF OBJECT_ID(N'[dbo].[FK_t_informacje_t_refundacja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_informacje] DROP CONSTRAINT [FK_t_informacje_t_refundacja];
GO
IF OBJECT_ID(N'[dbo].[FK_t_informacje_t_syno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_informacje] DROP CONSTRAINT [FK_t_informacje_t_syno];
GO
IF OBJECT_ID(N'[dbo].[FK_t_leki_t_producenci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_leki] DROP CONSTRAINT [FK_t_leki_t_producenci];
GO
IF OBJECT_ID(N'[dbo].[FK_t_produkty_t_leki]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_produkty] DROP CONSTRAINT [FK_t_produkty_t_leki];
GO
IF OBJECT_ID(N'[dbo].[FK_t_produkty_t_sklepy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_produkty] DROP CONSTRAINT [FK_t_produkty_t_sklepy];
GO
IF OBJECT_ID(N'[dbo].[FK_t_sklad_t_leki]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_sklad] DROP CONSTRAINT [FK_t_sklad_t_leki];
GO
IF OBJECT_ID(N'[dbo].[FK_t_sklepy_t_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_sklepy] DROP CONSTRAINT [FK_t_sklepy_t_users];
GO
IF OBJECT_ID(N'[dbo].[FK_t_zamowienia_t_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_zamowienia] DROP CONSTRAINT [FK_t_zamowienia_t_users];
GO
IF OBJECT_ID(N'[dbo].[FK_t_zamowienia_t_users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_zamowienia] DROP CONSTRAINT [FK_t_zamowienia_t_users1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[t_CartItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_CartItems];
GO
IF OBJECT_ID(N'[dbo].[t_informacje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_informacje];
GO
IF OBJECT_ID(N'[dbo].[t_inter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_inter];
GO
IF OBJECT_ID(N'[dbo].[t_leki]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_leki];
GO
IF OBJECT_ID(N'[dbo].[t_producenci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_producenci];
GO
IF OBJECT_ID(N'[dbo].[t_produkty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_produkty];
GO
IF OBJECT_ID(N'[dbo].[t_refundacja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_refundacja];
GO
IF OBJECT_ID(N'[dbo].[t_sklad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_sklad];
GO
IF OBJECT_ID(N'[dbo].[t_sklepy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_sklepy];
GO
IF OBJECT_ID(N'[dbo].[t_substancje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_substancje];
GO
IF OBJECT_ID(N'[dbo].[t_syno]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_syno];
GO
IF OBJECT_ID(N'[dbo].[t_users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_users];
GO
IF OBJECT_ID(N'[dbo].[t_zamowienia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_zamowienia];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 't_informacje'
CREATE TABLE [dbo].[t_informacje] (
    [pk_lek_id_num] int  NOT NULL,
    [inter_id_num] int IDENTITY(1,1) NOT NULL,
    [syno_id_num] int  NOT NULL,
    [synozb_id_num] int  NULL,
    [ref_id_num] int  NOT NULL,
    [bez_rec_bool] bit  NULL,
    [polski_bool] bit  NULL,
    [kosmetyk_bool] bit  NULL,
    [homeo_bool] bit  NULL,
    [diet_bool] bit  NULL,
    [antykonc_bool] bit  NULL,
    [surowiec_bool] bit  NULL,
    [opak_bool] bit  NULL,
    [surowica_bool] bit  NULL,
    [szczep_bool] bit  NULL,
    [iniek_bool] bit  NULL,
    [opatr_bool] bit  NULL,
    [szew_bool] bit  NULL,
    [prot_bool] bit  NULL,
    [diag_bool] bit  NULL,
    [socz_bool] bit  NULL,
    [sanit_bool] bit  NULL,
    [dezyn_bool] bit  NULL,
    [pomoc_bool] bit  NULL,
    [weteryn_bool] bit  NULL,
    [doping_bool] bit  NULL,
    [inny_bool] bit  NULL,
    [wersja_date] datetime  NULL
);
GO

-- Creating table 't_inter'
CREATE TABLE [dbo].[t_inter] (
    [pk_inter_id_num] int  NOT NULL,
    [nazwa_char] varchar(255)  NULL
);
GO

-- Creating table 't_leki'
CREATE TABLE [dbo].[t_leki] (
    [pk_lek_id_num] int  NOT NULL,
    [nazwa_char] varchar(255)  NOT NULL,
    [postac_char] varchar(255)  NULL,
    [opak_char] varchar(255)  NULL,
    [prod_id_num] int  NULL,
    [wersja_date] datetime  NULL
);
GO

-- Creating table 't_producenci'
CREATE TABLE [dbo].[t_producenci] (
    [pk_prod_id_num] int  NOT NULL,
    [nazwa_char] varchar(255)  NOT NULL
);
GO

-- Creating table 't_produkty'
CREATE TABLE [dbo].[t_produkty] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cena] decimal(19,4)  NOT NULL,
    [sklep_id] int  NOT NULL,
    [lek_id] int  NOT NULL,
    [ilosc] int  NOT NULL
);
GO

-- Creating table 't_refundacja'
CREATE TABLE [dbo].[t_refundacja] (
    [pk_ref_id_num] int  NOT NULL,
    [mode_char] varchar(255)  NULL
);
GO

-- Creating table 't_sklad'
CREATE TABLE [dbo].[t_sklad] (
    [pk_sklad_id_num] int IDENTITY(1,1) NOT NULL,
    [lek_id_num] int  NOT NULL,
    [sub_id_num] int  NOT NULL
);
GO

-- Creating table 't_sklepy'
CREATE TABLE [dbo].[t_sklepy] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] varchar(255)  NOT NULL,
    [Wlasciciel_id_user] int  NOT NULL
);
GO

-- Creating table 't_substancje'
CREATE TABLE [dbo].[t_substancje] (
    [pk_substancje_id_num] int IDENTITY(1,1) NOT NULL,
    [nazwa_char] varchar(255)  NOT NULL
);
GO

-- Creating table 't_syno'
CREATE TABLE [dbo].[t_syno] (
    [pk_syno_id_num] int  NOT NULL,
    [nazwa_char] varchar(255)  NULL
);
GO

-- Creating table 't_users'
CREATE TABLE [dbo].[t_users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Imie] varchar(255)  NOT NULL,
    [Nazwisko] varchar(255)  NOT NULL,
    [Login] varchar(255)  NOT NULL,
    [Haslo] varchar(50)  NOT NULL,
    [email] varchar(255)  NOT NULL,
    [Ulica] varchar(255)  NOT NULL,
    [Miasto] varchar(255)  NOT NULL,
    [KodPocztowy] varchar(255)  NOT NULL,
    [Admin] bit  NOT NULL
);
GO

-- Creating table 't_zamowienia'
CREATE TABLE [dbo].[t_zamowienia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [lek_data] nvarchar(max)  NULL,
    [sklep_id] int  NOT NULL,
    [status] varchar(50)  NULL
);
GO

-- Creating table 't_CartItems'
CREATE TABLE [dbo].[t_CartItems] (
    [RecordId] int IDENTITY(1,1) NOT NULL,
    [CartId] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [ProduktId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [pk_lek_id_num] in table 't_informacje'
ALTER TABLE [dbo].[t_informacje]
ADD CONSTRAINT [PK_t_informacje]
    PRIMARY KEY CLUSTERED ([pk_lek_id_num] ASC);
GO

-- Creating primary key on [pk_inter_id_num] in table 't_inter'
ALTER TABLE [dbo].[t_inter]
ADD CONSTRAINT [PK_t_inter]
    PRIMARY KEY CLUSTERED ([pk_inter_id_num] ASC);
GO

-- Creating primary key on [pk_lek_id_num] in table 't_leki'
ALTER TABLE [dbo].[t_leki]
ADD CONSTRAINT [PK_t_leki]
    PRIMARY KEY CLUSTERED ([pk_lek_id_num] ASC);
GO

-- Creating primary key on [pk_prod_id_num] in table 't_producenci'
ALTER TABLE [dbo].[t_producenci]
ADD CONSTRAINT [PK_t_producenci]
    PRIMARY KEY CLUSTERED ([pk_prod_id_num] ASC);
GO

-- Creating primary key on [Id] in table 't_produkty'
ALTER TABLE [dbo].[t_produkty]
ADD CONSTRAINT [PK_t_produkty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [pk_ref_id_num] in table 't_refundacja'
ALTER TABLE [dbo].[t_refundacja]
ADD CONSTRAINT [PK_t_refundacja]
    PRIMARY KEY CLUSTERED ([pk_ref_id_num] ASC);
GO

-- Creating primary key on [pk_sklad_id_num] in table 't_sklad'
ALTER TABLE [dbo].[t_sklad]
ADD CONSTRAINT [PK_t_sklad]
    PRIMARY KEY CLUSTERED ([pk_sklad_id_num] ASC);
GO

-- Creating primary key on [Id] in table 't_sklepy'
ALTER TABLE [dbo].[t_sklepy]
ADD CONSTRAINT [PK_t_sklepy]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [pk_substancje_id_num] in table 't_substancje'
ALTER TABLE [dbo].[t_substancje]
ADD CONSTRAINT [PK_t_substancje]
    PRIMARY KEY CLUSTERED ([pk_substancje_id_num] ASC);
GO

-- Creating primary key on [pk_syno_id_num] in table 't_syno'
ALTER TABLE [dbo].[t_syno]
ADD CONSTRAINT [PK_t_syno]
    PRIMARY KEY CLUSTERED ([pk_syno_id_num] ASC);
GO

-- Creating primary key on [Id] in table 't_users'
ALTER TABLE [dbo].[t_users]
ADD CONSTRAINT [PK_t_users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 't_zamowienia'
ALTER TABLE [dbo].[t_zamowienia]
ADD CONSTRAINT [PK_t_zamowienia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RecordId] in table 't_CartItems'
ALTER TABLE [dbo].[t_CartItems]
ADD CONSTRAINT [PK_t_CartItems]
    PRIMARY KEY CLUSTERED ([RecordId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [inter_id_num] in table 't_informacje'
ALTER TABLE [dbo].[t_informacje]
ADD CONSTRAINT [FK_t_informacje_t_inter]
    FOREIGN KEY ([inter_id_num])
    REFERENCES [dbo].[t_inter]
        ([pk_inter_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_informacje_t_inter'
CREATE INDEX [IX_FK_t_informacje_t_inter]
ON [dbo].[t_informacje]
    ([inter_id_num]);
GO

-- Creating foreign key on [pk_lek_id_num] in table 't_informacje'
ALTER TABLE [dbo].[t_informacje]
ADD CONSTRAINT [FK_t_informacje_t_leki]
    FOREIGN KEY ([pk_lek_id_num])
    REFERENCES [dbo].[t_leki]
        ([pk_lek_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ref_id_num] in table 't_informacje'
ALTER TABLE [dbo].[t_informacje]
ADD CONSTRAINT [FK_t_informacje_t_refundacja]
    FOREIGN KEY ([ref_id_num])
    REFERENCES [dbo].[t_refundacja]
        ([pk_ref_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_informacje_t_refundacja'
CREATE INDEX [IX_FK_t_informacje_t_refundacja]
ON [dbo].[t_informacje]
    ([ref_id_num]);
GO

-- Creating foreign key on [syno_id_num] in table 't_informacje'
ALTER TABLE [dbo].[t_informacje]
ADD CONSTRAINT [FK_t_informacje_t_syno]
    FOREIGN KEY ([syno_id_num])
    REFERENCES [dbo].[t_syno]
        ([pk_syno_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_informacje_t_syno'
CREATE INDEX [IX_FK_t_informacje_t_syno]
ON [dbo].[t_informacje]
    ([syno_id_num]);
GO

-- Creating foreign key on [prod_id_num] in table 't_leki'
ALTER TABLE [dbo].[t_leki]
ADD CONSTRAINT [FK_t_leki_t_producenci]
    FOREIGN KEY ([prod_id_num])
    REFERENCES [dbo].[t_producenci]
        ([pk_prod_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_leki_t_producenci'
CREATE INDEX [IX_FK_t_leki_t_producenci]
ON [dbo].[t_leki]
    ([prod_id_num]);
GO

-- Creating foreign key on [lek_id_num] in table 't_sklad'
ALTER TABLE [dbo].[t_sklad]
ADD CONSTRAINT [FK_t_sklad_t_leki]
    FOREIGN KEY ([lek_id_num])
    REFERENCES [dbo].[t_leki]
        ([pk_lek_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_sklad_t_leki'
CREATE INDEX [IX_FK_t_sklad_t_leki]
ON [dbo].[t_sklad]
    ([lek_id_num]);
GO

-- Creating foreign key on [sklep_id] in table 't_produkty'
ALTER TABLE [dbo].[t_produkty]
ADD CONSTRAINT [FK_t_produkty_t_sklepy]
    FOREIGN KEY ([sklep_id])
    REFERENCES [dbo].[t_sklepy]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_produkty_t_sklepy'
CREATE INDEX [IX_FK_t_produkty_t_sklepy]
ON [dbo].[t_produkty]
    ([sklep_id]);
GO

-- Creating foreign key on [sub_id_num] in table 't_sklad'
ALTER TABLE [dbo].[t_sklad]
ADD CONSTRAINT [FK_sub_id_num]
    FOREIGN KEY ([sub_id_num])
    REFERENCES [dbo].[t_substancje]
        ([pk_substancje_id_num])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_sub_id_num'
CREATE INDEX [IX_FK_sub_id_num]
ON [dbo].[t_sklad]
    ([sub_id_num]);
GO

-- Creating foreign key on [Wlasciciel_id_user] in table 't_sklepy'
ALTER TABLE [dbo].[t_sklepy]
ADD CONSTRAINT [FK_t_sklepy_t_users]
    FOREIGN KEY ([Wlasciciel_id_user])
    REFERENCES [dbo].[t_users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_sklepy_t_users'
CREATE INDEX [IX_FK_t_sklepy_t_users]
ON [dbo].[t_sklepy]
    ([Wlasciciel_id_user]);
GO

-- Creating foreign key on [lek_id] in table 't_produkty'
ALTER TABLE [dbo].[t_produkty]
ADD CONSTRAINT [FK_t_produkty_t_leki]
    FOREIGN KEY ([lek_id])
    REFERENCES [dbo].[t_leki]
        ([pk_lek_id_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_produkty_t_leki'
CREATE INDEX [IX_FK_t_produkty_t_leki]
ON [dbo].[t_produkty]
    ([lek_id]);
GO

-- Creating foreign key on [sklep_id] in table 't_zamowienia'
ALTER TABLE [dbo].[t_zamowienia]
ADD CONSTRAINT [FK_t_zamowienia_t_users]
    FOREIGN KEY ([sklep_id])
    REFERENCES [dbo].[t_sklepy]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_zamowienia_t_users'
CREATE INDEX [IX_FK_t_zamowienia_t_users]
ON [dbo].[t_zamowienia]
    ([sklep_id]);
GO

-- Creating foreign key on [user_id] in table 't_zamowienia'
ALTER TABLE [dbo].[t_zamowienia]
ADD CONSTRAINT [FK_t_zamowienia_t_users1]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[t_users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_t_zamowienia_t_users1'
CREATE INDEX [IX_FK_t_zamowienia_t_users1]
ON [dbo].[t_zamowienia]
    ([user_id]);
GO

-- Creating foreign key on [ProduktId] in table 't_CartItems'
ALTER TABLE [dbo].[t_CartItems]
ADD CONSTRAINT [FK__t_CartIte__Produ__59FA5E80]
    FOREIGN KEY ([ProduktId])
    REFERENCES [dbo].[t_produkty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__t_CartIte__Produ__59FA5E80'
CREATE INDEX [IX_FK__t_CartIte__Produ__59FA5E80]
ON [dbo].[t_CartItems]
    ([ProduktId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------