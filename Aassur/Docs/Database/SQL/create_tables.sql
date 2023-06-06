DROP TABLE IF EXISTS `clients`;
DROP TABLE IF EXISTS `contracts`;
DROP TABLE IF EXISTS `adress`;
DROP TABLE IF EXISTS `last_contacts`;
DROP TABLE IF EXISTS `meetings`;
DROP TABLE IF EXISTS `news`;
DROP TABLE IF EXISTS `l_civility`;
DROP TABLE IF EXISTS `l_type_client`;
DROP TABLE IF EXISTS `l_city`;
DROP TABLE IF EXISTS `l_family_status`;
DROP TABLE IF EXISTS `l_type_contract`;
DROP TABLE IF EXISTS `l_company`;

CREATE TABLE `clients`
(
    `id`                          INTEGER PRIMARY KEY AUTOINCREMENT,
    `civility_id`                 INTEGER,
    `first_name`                  TEXT,
    `last_name`                   TEXT,
    `type_client_id`              INTEGER,
    `adress_id`                   INTEGER,
    `city_id`                     INTEGER,
    `mobile_number`               TEXT,
    `fixe_number`                 TEXT,
    `mail`                        TEXT,
    `country_of_residence`        TEXT,
    `date_of_birth`               DATE,
    `family_status_id`            INTEGER,
    `function`                    TEXT,
    `foyer`                       TEXT,
    `hobbies`                     TEXT,
    `related_customers_client_id` INTEGER,
    `creation_date`               DATE,
    `origin`                      TEXT,
    `note`                        TEXT,
    FOREIGN KEY (`civility_id`) REFERENCES `l_civility` (`id`),
    FOREIGN KEY (`type_client_id`) REFERENCES `l_type_client` (`id`),
    FOREIGN KEY (`adress_id`) REFERENCES `adress` (`id`),
    FOREIGN KEY (`city_id`) REFERENCES `l_city` (`id`),
    FOREIGN KEY (`family_status_id`) REFERENCES `l_family_status` (`id`),
    FOREIGN KEY (`related_customers_client_id`) REFERENCES `clients` (`id`)
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
    FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`),
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
    FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`)
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

CREATE TABLE `l_civility`
(
    `id`   INTEGER PRIMARY KEY AUTOINCREMENT,
    `name` TEXT
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
