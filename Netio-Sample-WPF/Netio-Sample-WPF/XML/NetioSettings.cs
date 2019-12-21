using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Netio_Sample_WPF.XML
{
    public class NetioSettings
   {

        #region Serializzazione

        #region Write

        ///<summary> 
        /// Serializza la classe Menus su un file in formato XML 
        ///</summary> 
        ///<param name="pXmlPath">Path del file da generare</param> 
        ///<remarks></remarks> 
        public void WriteXml(string pXmlPath)
        {
            try
            {
                SerializeToFile(pXmlPath, this, typeof(NetioSettings));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <param name="pPath">The p path.</param>
        /// <param name="pObjToSerialize">The p obj to serialize.</param>
        /// <param name="pTypeToSerialize">The p type to serialize.</param>
        public static void SerializeToFile(string pPath, object pObjToSerialize, Type pTypeToSerialize)
        {
            using (XmlTextWriter writer = new XmlTextWriter(pPath, Encoding.UTF8))
            {
                // write a readable file 
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                // Occorre un'istanza della classe XmlSerializer 
                XmlSerializer serializer = new XmlSerializer(pTypeToSerialize);

                // e questo é tutto ciò che serve per persistere i dati 
                serializer.Serialize(writer, pObjToSerialize);
            }
        }

        #endregion

        #region Read

            ///<summary>
            /// Deserializza una classe LicenseElements da un file o da una stringa XML
            ///</summary>
            ///<param name="pXml">Nome file xml o stringa classe serializzata</param>
            ///<returns>Ritorna: Un oggetto di tipo LicenseElements</returns>
            ///<remarks>
            ///</remarks>
            public static NetioSettings ReadXml(string pXml, bool pIsXmlData)
            {
            NetioSettings ret = null;
                try
                {
                    //ret = (NetioSettings)DeserializeFromString(typeof(NetioSettings), pXml);
                    ret = (NetioSettings)DeserializeFromFile(typeof(NetioSettings), new Type[] { typeof(NetioSettings) }, pXml);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return (ret);
            }

            /// <summary>
            /// Deserializes from file.
            /// </summary>
            /// <param name="pTypeToDeserialize">The p type to deserialize.</param>
            /// <param name="pExtraTypes">The p extra types.</param>
            /// <param name="pPath">The p path.</param>
            /// <returns></returns>
            public static object DeserializeFromFile(Type pTypeToDeserialize, Type[] pExtraTypes, string pPath)
            {
                object ret = null;

                using (XmlTextReader reader = new XmlTextReader(pPath))
                {
                    // Occorre un'istanza della classe XmlSerializer 
                    XmlSerializer serializer = new XmlSerializer(pTypeToDeserialize, pExtraTypes);
                    // e questo é tutto ciò che serve per leggere i dati dal formato XML 
                    ret = serializer.Deserialize(reader);
                }
                return (ret);
            }



        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="pTypeToDeserialize">The p type to deserialize.</param>
        /// <param name="pXmlString">The p XML string.</param>
        /// <returns></returns>
        public static object DeserializeFromString(Type pTypeToDeserialize, string pXmlString)
            {
                object ret = null;
                using (XmlReader xr = BuildReader(pXmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(pTypeToDeserialize);
                    ret = serializer.Deserialize(xr);
                    xr.Close();
                }
                return (ret);
            }

            /// <summary>
            /// Builds the reader.
            /// </summary>
            /// <param name="pXmlString">The p XML string.</param>
            /// <returns></returns>
            public static XmlTextReader BuildReader(string pXmlString)
            {
                NameTable nt = new NameTable();
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
                nsmgr.AddNamespace("bk", "urn:sample");

                XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

                return (new XmlTextReader(pXmlString, XmlNodeType.Element, context));
            }
        #endregion

        #endregion

        /// <summary>
        /// AddressNetio1
        /// </summary>
        private string mAddressNetio1;

        /// <summary>
        /// AddressNetio1
        /// </summary>
        public string AddressNetio1
        {
            get
            {
                return mAddressNetio1;
            }
            set
            {
                mAddressNetio1 = value;
            }
        }


        /// <summary>
        /// AddressNetio2
        /// </summary>
        private string mAddressNetio2;

        /// <summary>
        /// AddressNetio2
        /// </summary>
        public string AddressNetio2
        {
            get
            {
                return mAddressNetio2;
            }
            set
            {
                mAddressNetio2 = value;
            }
        }


        /// <summary>
        /// UserNameNetio1
        /// </summary>
        private string mUserNameNetio1;

        /// <summary>
        /// UserNameNetio1
        /// </summary>
        public string UserNameNetio1
        {
            get
            {
                return mUserNameNetio1;
            }
            set
            {
                mUserNameNetio1 = value;
            }
        }


        /// <summary>
        /// UserNameNetio2
        /// </summary>
        private string mUserNameNetio2;

        /// <summary>
        /// UserNameNetio2
        /// </summary>
        public string UserNameNetio2
        {
            get
            {
                return mUserNameNetio2;
            }
            set
            {
                mUserNameNetio2 = value;
            }
        }


        /// <summary>
        /// PasswordNetio1
        /// </summary>
        private string mPasswordNetio1;

        /// <summary>
        /// PasswordNetio1
        /// </summary>
        public string PasswordNetio1
        {
            get
            {
                return mPasswordNetio1;
            }
            set
            {
                mPasswordNetio1 = value;
            }
        }


        /// <summary>
        /// PasswordNetio2
        /// </summary>
        private string mPasswordNetio2;

        /// <summary>
        /// PasswordNetio2
        /// </summary>
        public string PasswordNetio2
        {
            get
            {
                return mPasswordNetio2;
            }
            set
            {
                mPasswordNetio2 = value;
            }
        }







    }
}
