DROP TABLE IF EXISTS `Client`;
DROP TABLE IF EXISTS `Contract`;
DROP TABLE IF EXISTS `Address`;
DROP TABLE IF EXISTS `LastContact`;
DROP TABLE IF EXISTS `Meeting`;
DROP TABLE IF EXISTS `News`;
DROP TABLE IF EXISTS `ListCivility`;
DROP TABLE IF EXISTS `ListTypeClient`;
DROP TABLE IF EXISTS `ListCity`;
DROP TABLE IF EXISTS `ListFamilyStatus`;
DROP TABLE IF EXISTS `ListTypeContract`;
DROP TABLE IF EXISTS `ListCompany`;

CREATE TABLE `Client`
(
    `Id`                       integer not null primary key autoincrement,
    `CivilityId`               integer,
    `FirstName`                varchar,
    `LastName`                 varchar,
    `TypeClientId`             integer,
    `AddressId`                integer,
    `CityId`                   integer,
    `MobileNumber`             varchar,
    `FixeNumber`               varchar,
    `Mail`                     varchar,
    `CountryOfResidence`       varchar,
    `DateOfBirth`              bigint,
    `FamilyStatusId`           integer,
    `Function`                 varchar,
    `Foyer`                    varchar,
    `Hobbies`                  varchar,
    `RelatedCustomersClientId` integer,
    `CreationDate`             bigint,
    `Origin`                   varchar,
    `Note`                     varchar,
    foreign key (`CivilityId`) references ListCivility (`Id`),
    foreign key (`TypeClientId`) references `ListTypeClient` (`Id`),
    foreign key (`AddressId`) references `Address` (`Id`),
    foreign key (`CityId`) references `ListCity` (`Id`),
    foreign key (`FamilyStatusId`) references `ListFamilyStatus` (`Id`),
    foreign key (`RelatedCustomersClientId`) references `Client` (`Id`)
);
CREATE INDEX Idx_Client_Id ON Client (Id);
CREATE INDEX Idx_Client_CivilityId ON Client (CivilityId);
CREATE INDEX Idx_Client_TypeClientId ON Client (TypeClientId);
CREATE INDEX Idx_Client_AddressId ON Client (AddressId);
CREATE INDEX Idx_Client_CityId ON Client (CityId);
CREATE INDEX Idx_Client_FamilyStatusId ON Client (FamilyStatusId);
CREATE INDEX Idx_Client_RelatedCustomersClientId ON Client (RelatedCustomersClientId);

CREATE TABLE `Contract`
(
    `Id`             integer primary key autoincrement,
    `ClientId`       integer,
    `TypeContractId` integer,
    `CompanyId`      integer,
    `ContractName`   varchar,
    `Encours`        integer,
    `OpeningDate`    bigint,
    foreign key (`ClientId`) references `Client` (`Id`),
    foreign key (`TypeContractId`) references `ListTypeContract` (`Id`),
    foreign key (`CompanyId`) references `ListCompany` (`Id`)
);
CREATE INDEX Idx_Contract_Id ON Contract (Id);
CREATE INDEX Idx_Contract_ClientId ON Contract (ClientId);
CREATE INDEX Idx_Contract_TypeContractId ON Contract (TypeContractId);
CREATE INDEX Idx_Contract_CompanyId ON Contract (CompanyId);

CREATE TABLE `Address`
(
    `Id`      integer primary key autoincrement,
    `Name`    varchar,
    `CoordX`  double,
    `CoordY`  double
);
CREATE INDEX Idx_Address_Id ON Address (Id);

CREATE TABLE `LastContact`
(
    `Id`       integer primary key autoincrement,
    `ClientId` integer,
    `Date`     bigint,
    `Mode`     varchar,
    `Note`     varchar,
    foreign key (`ClientId`) references `Client` (`Id`)
);
CREATE INDEX Idx_LastContact_Id ON LastContact (Id);
CREATE INDEX Idx_LastContact_ClientId ON LastContact (ClientId);

CREATE TABLE `Meeting`
(
    `Id`   integer primary key autoincrement,
    `Date` bigint,
    `Name` varchar
);
CREATE INDEX Idx_Meeting_Id ON Meeting (Id);

CREATE TABLE `News`
(
    `Id`   integer primary key autoincrement,
    `Date` bigint,
    `Note` varchar
);
CREATE INDEX Idx_News_Id ON News (Id);

CREATE TABLE ListCivility
(
    `Id`   integer primary key autoincrement,
    `Name` varchar(3)
);
CREATE INDEX Idx_ListCivility_Id ON ListCivility (Id);

CREATE TABLE `ListTypeClient`
(
    `Id`   integer primary key autoincrement,
    `Name` varchar
);
CREATE INDEX Idx_ListTypeClient_Id ON ListTypeClient (Id);

CREATE TABLE `ListCity`
(
    `Id`         integer primary key autoincrement,
    `Insee`      varchar(5),
    `PostalCode` varchar(5),
    `Name`       varchar,
    `CoordX`     double,
    `CoordY`     double
);
CREATE INDEX Idx_ListCity_Id ON ListCity (Id);

CREATE TABLE `ListFamilyStatus`
(
    `Id`   integer primary key autoincrement,
    `Name` varchar
);
CREATE INDEX Idx_ListFamilyStatus_Id ON ListFamilyStatus (Id);

CREATE TABLE `ListTypeContract`
(
    `Id`   integer primary key autoincrement,
    `Name` varchar
);
CREATE INDEX Idx_ListTypeContract_Id ON ListTypeContract (Id);

CREATE TABLE `ListCompany`
(
    `Id`      integer primary key autoincrement,
    `Name`    varchar,
    `Partner` integer(1)
);
CREATE INDEX Idx_ListCompany_Id ON ListCompany (Id);
