DROP TABLE IF EXISTS `clients`;
DROP TABLE IF EXISTS `contrats`;
DROP TABLE IF EXISTS `last_contact`;
DROP TABLE IF EXISTS `meetings`;
DROP TABLE IF EXISTS `news`;
DROP TABLE IF EXISTS `l_civility`;
DROP TABLE IF EXISTS `l_type_client`;
DROP TABLE IF EXISTS `l_city`;
DROP TABLE IF EXISTS `l_family_status`;
DROP TABLE IF EXISTS `l_type_contrats`;
DROP TABLE IF EXISTS `l_companies`;

CREATE TABLE `clients`
(
    `id`                          INTEGER PRIMARY KEY,
    `civility_id`                 INTEGER,
    `first_name`                  TEXT,
    `last_name`                   TEXT,
    `type_client_id`              INTEGER,
    `adress`                      TEXT,
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
    FOREIGN KEY (`city_id`) REFERENCES `l_city` (`id`),
    FOREIGN KEY (`family_status_id`) REFERENCES `l_family_status` (`id`),
    FOREIGN KEY (`related_customers_client_id`) REFERENCES `clients` (`id`)
);

CREATE TABLE `contrats`
(
    `id`               INTEGER PRIMARY KEY,
    `client_id`        INTEGER,
    `type_contrats_id` INTEGER,
    `companie_id`      INTEGER,
    `contrat_name`     TEXT,
    `encours`          INTEGER,
    `opening_date`     DATE,
    FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`),
    FOREIGN KEY (`type_contrats_id`) REFERENCES `l_type_contrats` (`id`),
    FOREIGN KEY (`companie_id`) REFERENCES `l_companies` (`id`)
);

CREATE TABLE `last_contact`
(
    `id`        INTEGER PRIMARY KEY,
    `client_id` INTEGER,
    `date`      DATE,
    `mode`      TEXT,
    `note`      TEXT,
    FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`)
);

CREATE TABLE `meetings`
(
    `id`   INTEGER PRIMARY KEY,
    `date` DATE,
    `name` TEXT
);

CREATE TABLE `news`
(
    `id`   INTEGER PRIMARY KEY,
    `date` DATE,
    `note` TEXT
);

CREATE TABLE `l_civility`
(
    `id`   INTEGER PRIMARY KEY,
    `name` TEXT
);

CREATE TABLE `l_type_client`
(
    `id`   INTEGER PRIMARY KEY,
    `name` TEXT
);

CREATE TABLE `l_city`
(
    `id`          INTEGER PRIMARY KEY,
    `insee`       TEXT,
    `postal_code` TEXT,
    `name`        TEXT,
    `coord_x`     REAL,
    `coord_y`     REAL
);

CREATE TABLE `l_family_status`
(
    `id`   INTEGER PRIMARY KEY,
    `name` TEXT
);

CREATE TABLE `l_type_contrats`
(
    `id`   INTEGER PRIMARY KEY,
    `name` TEXT
);

CREATE TABLE `l_companies`
(
    `id`      INTEGER PRIMARY KEY,
    `name`    TEXT,
    `partner` INTEGER
);
