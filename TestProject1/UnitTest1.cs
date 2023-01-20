using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using ServiceLayer.Services;

namespace TestProject1
{
    public class UnitTest1
    {
   
        public UnitTest1()
        {

        }

        [Fact]
        public void TestEncryptionDecryption()
        {
           
            // Arrange
            var fileEncryption = new FileEncryption();
            var testText = "This is a test file.";
            var testFilePath = "testfile.txt";
            File.WriteAllText(testFilePath, testText);
            var file = File.OpenRead("testfile.txt");           
            var formFile = new FormFile(file, 0, file.Length, "testfile", "testfile.txt");      
            var password = "123456";

            var outputEncryptedPath = "encrypted.txt";
            var outputDecryptedPath = "decrypted.txt";

            // Act
            fileEncryption.EncryptFile(formFile, password, outputEncryptedPath);
            var filetest = File.OpenRead("encrypted.txt");
            var fomeFileEncrypted = new FormFile(filetest, 0, filetest.Length, "encrypted", "encrypted.txt");

            fileEncryption.DecryptFile(fomeFileEncrypted, password, outputDecryptedPath);

            // Assert
            Assert.True(File.Exists(outputEncryptedPath));         
            Assert.True(File.Exists(outputDecryptedPath));

            var originalContent = File.ReadAllText("testfile.txt");
            var decryptedContent = File.ReadAllText(outputDecryptedPath);

            Assert.Equal(originalContent, decryptedContent);

            // Cleanup
            file.Close();
            filetest.Close();
            File.Delete(testFilePath);
            File.Delete(outputEncryptedPath);
            File.Delete(outputDecryptedPath);
        }

    }
}