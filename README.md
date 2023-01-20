[![.NET Core Desktop](https://github.com/rene069/VaultProject--H4/actions/workflows/dotnet-desktoptest.yml/badge.svg)](https://github.com/rene069/VaultProject--H4/actions/workflows/dotnet-desktoptest.yml)


# File Encryption and Decryption Methods

This repository contains methods for encrypting and decrypting files using the AES algorithm. These methods use IFormFile for filepath and the password provided by the user to encrypt or decrypt the file.

## Encrypt File

This method encrypts a given file using the provided password and saves the encrypted file to a specified output path.

**Input**

-   IFormFile : The file to be encrypted.
-   string : The password to be used for encryption.
-   string : The output path where the encrypted file should be saved.

**Output**

-   Encrypted.txt: file is saved in Files Folder

## Decrypt File

This method decrypts a given file using the provided password and saves the decrypted file to a specified output path.

**Input**

-   IFormFile : The file to be decrypted.
-   string : The password used to encrypt the file.
-   string : The output path where the decrypted file should be saved.

**Output**

-   Decrypted.txt: file is saved in Files Folder

## Usage

1.  Import the FileEncryptionService in your project
2.  Use the EncryptFile method to encrypt your file and provide the path, password and the file.
3.  Use the DecryptFile method to decrypt your file and provide the path, password and the file.

## ToDo

 - [ ] Added Salt to password for more secure encryption
 - [ ] Save Salt in SQL  database 

# Web API

This repository also contains a sample Web API implementation for the file encryption and decryption methods. The Web API has two endpoints, one for encrypting a file and one for decrypting a file.

## EncryptFile

This endpoint encrypts a given file using the provided password and saves the encrypted file to a specified output path.

**URL** : `/EncryptFile`

**Method** : `POST`

**Data** :

-   IFormFile : The file to be encrypted.
-   string : The password to be used for encryption.

**Success Response**

-   Code : `200 OK`

## DecryptFile

This endpoint decrypts a given file using the provided password and saves the decrypted file to a specified output path.

**URL** : `/DecryptFile`

**Method** : `POST`

**Data** :

-   IFormFile : The file to be decrypted.
-   string : The password used to encrypt the file.

**Success Response**

-   Code : `200 OK`

## Usage

1.  Call the EncryptFile endpoint to encrypt your file and provide the path, password and the file.
2.  Call the DecryptFile endpoint to decrypt your file and provide the path, password and the file.
