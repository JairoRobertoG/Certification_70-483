using Certification.Classes;
using Certification.Models;
using Certification.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;

namespace Certification.Chapters.Objective_3
{
    class DebugApplicationsAndImplementSecurity
    {
        public DebugApplicationsAndImplementSecurity() { }

        //Objective 3.1: Validate application input
        //LISTING 3-1 Customer and Address classes
        //LISTING 3-2 Saving a new customer to the database
        public void SavingNewCustomerToTheDataBase()
        {
            using (ShopContext ctx = new ShopContext())
            {
                Address a = new Address
                {
                    AddressLine1 = "Somewhere 1",
                    AddressLine2 = "At some floor",
                    City = "SomeCity",
                    ZipCode = "1111AA"
                };

                Customer c = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BillingAddress = a,
                    ShippingAddress = a,
                };

                ctx.Customers.Add(c);
                ctx.SaveChanges();
            }
        }

        //LISTING 3-3 Running manual validation
        //Using Parse, TryParse, and Convert

        //LISTING 3-4 Using Parse
        public void UsingParse()
        {
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True
        }

        //LISTING 3-5 Using TryParse
        public void UsingTryParse()
        {
            string value = "1";
            int result;
            bool success = int.TryParse(value, out result);
            if (success)
            {
                // value is a valid integer, result contains the value
            }
            else
            {
                // value is not a valid integer
            }
        }

        //LISTING 3-6 Using configuration options when parsing a number
        public void UsingConfigurationOptionsWhenParsingNumber()
        {
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");
            string value = "€19,95";
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english)); // Displays 19.95
            Console.ReadLine();
        }

        //LISTING 3-7 Using Convert with a null value
        public void UsingConvertWithNullValue()
        {
            int i = Convert.ToInt32(null);
            Console.WriteLine(i); // Displays 0
            Console.ReadLine();
        }

        //LISTING 3-8 Using Convert to convert from double to int
        public void UsingConvertToConvertFromDoubleToInt()
        {
            double d = 23.15;
            int i = Convert.ToInt32(d);
            Console.WriteLine(i); // Displays 23
        }

        //LISTING 3-9 Manually validating a ZIP Code
        private bool ValidateZipCode(string zipCode)
        {
            // Valid zipcodes: 1234AB | 1234 AB | 1001 AB
            if (zipCode.Length < 6) return false;
            string numberPart = zipCode.Substring(0, 4);
            int number;
            if (!int.TryParse(numberPart, out number)) return false;
            string characterPart = zipCode.Substring(4);
            if (numberPart.StartsWith("0")) return false;
            if (characterPart.Trim().Length < 2) return false;
            if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
                return false;
            return true;
        }

        public void ManuallyValidatingZIPCode()
        {
            var zip_code = "1234AB";
            var success = ValidateZipCode(zip_code);
        }

        //LISTING 3-10 Validate a ZIP Code with a regular expression
        static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public void ValidateZIPCodeWithRegularExpression()
        {
            var zip_code = "1234AB";
            var success = ValidateZipCodeRegEx(zip_code);
        }

        //LISTING 3-11 Validate a ZIP Code with a regular expression
        public void ValidateZIPCodeWithRegularExpressionTest()
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            string input = "1 2 3 4 5";
            string result = regex.Replace(input, " ");
            Console.WriteLine(result); // Displays 1 2 3 4 5
            Console.ReadLine();
        }

        //LISTING 3-12 Seeing whether a string contains potential JSON data
        private bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]");
        }

        public void SeeingWhetherStringContainsPotentialJSONData()
        {
            var success = IsJson("{name: 'jairo'}");
        }

        //LISTING 3-13 Deserializing an object with the JavaScriptSerializer
        public void DeserializingAnObjectWithJavaScriptSerializer()
        {
            Address a = new Address
            {
                AddressLine1 = "Somewhere 1",
                AddressLine2 = "At some floor",
                City = "SomeCity",
                ZipCode = "1111AA"
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(a);
            
            var result = serializer.Deserialize<Dictionary<string, object>>(json);
        }

        //LISTING 3-14 A sample XML with person data
        public void ASampleXMLWithPersonData()
        {
            string xsdPath = "person.xsd";
            string xmlPath = "person.xml";
            XmlReader reader = XmlReader.Create(xmlPath);
            XmlDocument document = new XmlDocument();
            document.Schemas.Add("", xsdPath);
            document.Load(reader);
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }

        //Objective 3.2 Perform symmetric and asymmetric encryption
        //Working with encryption in the .NET Framework
        //LISTING 3-17 Use a symmetric encryption algorithm
        private byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt =
                new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public void UseSymetricEncryptionAlgorithm()
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                // Displays: My secret data!
                Console.WriteLine("Original: {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
                Console.ReadLine();
            }
        }

        //LISTING 3-18 Exporting a public key
        public void ExportingPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine(publicKeyXML);
            Console.WriteLine(privateKeyXML);
        }

        //LISTING 3-19 Using a public and private key to encrypt and decrypt data
        public void UsingPublicAndPrivateKeyToEncryptAndDecryptData()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }
            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }

        //LISTING 3-21 A naïve set implementation
        //LISTING 3-22 A set implementation that uses hashing
        //LISTING 3-23 Using SHA256Managed to calculate a hash code
        public void UsingSHA256ManagedToCalculateHashCode() 
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            string data = "A paragraph of text";
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text";
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));
            data = "A paragraph of text";
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
            Console.WriteLine(hashA.SequenceEqual(hashB)); // Displays: false
            Console.WriteLine(hashA.SequenceEqual(hashC)); // Displays: true
        }

        //Managing and creating certificates
        //LISTING 3-24 Signing and verifying data with a certificate
        public void SigningAndVerifyingDataWithCertificate()
        {
            SignAndVerify();
        }

        public static void SignAndVerify()
        {
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "cn = WouterDeKort");
            // Uncomment this line to make the verification step fail
            //signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }

        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash,
            CryptoConfig.MapNameToOID("SHA1"),
            signature);
        }

        private static byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore",
            StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }

        //LISTING 3-25 Declarative CAS
        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public void DeclarativeCAS()
        {
            // Method body
        }

        //LISTING 3-26 Imperative CAS
        public void ImperativeCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        //LISTING 3-27 Initializing a SecureString
        public void InitializingSecureString()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }

                ss.MakeReadOnly();
            }
        }

        //LISTING 3-28 Getting the value of a SecureString
        private void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            Console.ReadLine();
        }

        public void GettingValueOfSecureString()
        {
            SecureString ss = new SecureString();
            ss.AppendChar('p');
            ConvertToUnsecureString(ss);
        }

        //What is an assembly?
        //Signing assemblies using a strong name
        //LISTING 3-29 Inspecting the public key of a signed assembly
        //Putting an assembly in the GAC
        //Versioning assemblies
        //LISTING 3-30 Redirecting assembly bindings to a newer version
        //LISTING 3-31 Specifying additional locations for assemblies
        //Creating a WinMD assembly
        //Objective 3.4 Debug an application

        //LISTING 3-33 A simple console application
        private void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }

        public void SimpleConsoleApplication()
        {
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Console.ReadLine();
        }

        //Creating and managing compiler directives
        //LISTING 3-34 Checking for the debug symbol
        public void CheckingForTheDebugSymbol()
        {
            #if DEBUG
                Console.WriteLine("Debug mode");
            #else
                Console.WriteLine("Not debug");
            #endif
            Console.ReadLine();
        }

        //LISTING 3-35 Defining a custom symbol
        //#define MySymbol
        //..
        public void DefiningCustomSymbol()
        {
            #if MySymbol
                 Console.WriteLine("Custom symbol is defined");
            #endif
        }

        //LISTING 3-36 Using preprocessor directives to target multiple platforms
        private Assembly LoadAssembly<T>()
        {
            #if !WINRT
                Assembly assembly = typeof(T).Assembly;
            #else
                Assembly assembly = typeof(T).GetTypeInfo().Assembly;
            #endif

            return assembly;
        }

        public void UsingPreprocessorDirectivesToTargetMultiplePlatforms()
        {
            LoadAssembly<Person>();
        }

        //LISTING 3-37 The warning and error directives
        public void TheWarningAndErrorDirectives()
        {
            //#warning This code is obsolete
            //#if DEBUG
            //    #error Debug build is not allowed
            //#endif
        }

        //LISTING 3-38 The line directive
        #line 200 "OtherFileName"
                int a; // line 200
        #line default
                int b; // line 4
        #line hidden
                int c; // hidden
                int d; // line 7

        //LISTING 3-39 The pragma warning directive
        public void ThePragmaWarningDirective()
        {
            #pragma warning disable
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
            #pragma warning restore
        }

        //LISTING 3-40 Disabling and enabling specific warnings
        public void DisablingAndEnablingSpecificWarnings()
        {
            #pragma warning disable 0162, 0168
            int i;
            #pragma warning restore 0162
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
            #pragma warning restore
        }

        //LISTING 3-41 Call a method only in a debug build
        [Conditional("DEBUG")]
        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void CallMethodOnlyInDebugBuild()
        {
            #if DEBUG
            Log("Step1");
            #endif
        }

        //LISTING 3-42 Applying the ConditionalAttribute
        public void ApplyingTheConditionalAttribute()
        {
            Log("message");
        }

        //LISTING 3-43 Applying the DebuggerDisplayAttribute
        public void ApplyingTheDebbugerDisplayAttribute()
        {
            var person = new PersonDebug();
            person.FirstName = "Jairo";
            person.LastName = "Gomez";
        }

        //LISTING 3-44 Examining PDB files
        public void ExaminingPDBFiles()
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }

        //Objective 3.5 Implement diagnostics in an application
        //Logging and tracing
        //LISTING 3-45 Using the Debug class
        public void UsingTheDebugClass()
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }

        //LISTING 3-46 Using the TraceSource class
        public void UsingTheTraceSourceClass()
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1,
            new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();
        }

        //LISTING 3-47 Configuring TraceListener.
        public void ConfiguringTraceListener()
        {
            Stream outputFile = File.Create("tracefile.txt");
            TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.Listeners.Clear();
            traceSource.Listeners.Add(textListener);
            traceSource.TraceInformation("Trace output");
            traceSource.Flush();
            traceSource.Close();
        }

        //LISTING 3-48 Using a configuration file for tracing
    }
}
