DROP TABLE IF EXISTS `Client`;
DROP TABLE IF EXISTS `contracts`;
DROP TABLE IF EXISTS `adress`;
DROP TABLE IF EXISTS `last_contacts`;
DROP TABLE IF EXISTS `meetings`;
DROP TABLE IF EXISTS `news`;
DROP TABLE IF EXISTS ListCivility;
DROP TABLE IF EXISTS `l_type_client`;
DROP TABLE IF EXISTS `l_city`;
DROP TABLE IF EXISTS `l_family_status`;
DROP TABLE IF EXISTS `l_type_contract`;
DROP TABLE IF EXISTS `l_company`;

CREATE TABLE `Client`
(
    `Id`                       integer primary key autoincrement,
    `CivilityId`               integer,
    `FirstName`                varchar,
    `LastName`                 varchar,
    `TypeClientId`             integer,
    `AdressId`                 integer,
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
    foreign key (`TypeClientId`) references `l_type_client` (`id`),
    foreign key (`AdressId`) references `adress` (`id`),
    foreign key (`CityId`) references `l_city` (`id`),
    foreign key (`FamilyStatusId`) references `l_family_status` (`id`),
    foreign key (`RelatedCustomersClientId`) references `Client` (`id`)
);

CREATE TABLE `contracts`
(
    `id`               INTEGER PRIMARY KEY AUTOINCREMENT,
    `client_id`        INTEGER,
    `type_contract_id` INTEGER,
    `company_id`       INTEGER,
    `contract_name`    TEXT,
    `encours`          INTEGER,
    `opening_date`     DATE,
    FOREIGN KEY (`client_id`) REFERENCES `Client` (`id`),
    FOREIGN KEY (`type_contract_id`) REFERENCES `l_type_contract` (`id`),
    FOREIGN KEY (`company_id`) REFERENCES `l_company` (`id`)
);

CREATE TABLE `adress`
(
    `id`      INTEGER PRIMARY KEY AUTOINCREMENT,
    `adress`  TEXT,
    `coord_x` DOUBLE,
    `coord_y` DOUBLE
);

CREATE TABLE `last_contacts`
(
    `id`        INTEGER PRIMARY KEY AUTOINCREMENT,
    `client_id` INTEGER,
    `date`      DATE,
    `mode`      TEXT,
    `note`      TEXT,
    FOREIGN KEY (`client_id`) REFERENCES `Client` (`id`)
);

CREATE TABLE `meetings`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `date` DATE,
    `name` TEXT
);

CREATE TABLE `news`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `date` DATE,
    `note` TEXT
);

CREATE TABLE ListCivility
(
    `Id`   integer primary key autoincrement,
    `Name` varchar
);

CREATE TABLE `l_type_client`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `name` TEXT
);

CREATE TABLE `l_city`
(
    `id`          INTEGER PRIMARY KEY AUTOINCREMENT,
    `insee`       TEXT,
    `postal_code` TEXT,
    `name`        TEXT,
    `coord_x`     REAL,
    `coord_y`     REAL
);

CREATE TABLE `l_family_status`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `name` TEXT
);

CREATE TABLE `l_type_contract`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `name` TEXT
);

CREATE TABLE `l_company`
(
    `id`      INTEGER PRIMARY KEY AUTOINCREMENT,
    `name`    TEXT,
    `partner` INTEGER
);
