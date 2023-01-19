CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS chores(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        Name VARCHAR(50) NOT NULL,
        Difficulty int NOT NULL,
        Location VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    chores (
        Name,
        `Difficulty`,
        `Location`,
        `creatorId`
    )
VALUES (
        'Take out garbage AGAIN',
        4,
        'Outside',
        '639cc49b47c35d04a02a81f0'
    );