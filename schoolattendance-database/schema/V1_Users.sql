-- ################################################################
-- Table for roles
-- ################################################################
CREATE TABLE IF NOT EXISTS master_roles (
    role_id INT AUTO_INCREMENT PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ################################################################
-- insert roles
-- ################################################################
INSERT INTO master_roles (role_name) VALUES
('auxiliar'),
('profesor');

-- ################################################################
-- Table for master_users
-- ################################################################
CREATE TABLE IF NOT EXISTS master_users (
    user_id VARCHAR(36) PRIMARY KEY NOT NULL,
    identification TEXT NOT NULL,
    full_name VARCHAR(255) NOT NULL,
    email TEXT NOT NULL,
    password TEXT NOT NULL,
    role_id INT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_master_roles FOREIGN KEY (role_id) REFERENCES master_roles(role_id)
) ENGINE = InnoDB DEFAULT CHARSET = latin1;

