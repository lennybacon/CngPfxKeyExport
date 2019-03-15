namespace Sample
{
  internal partial class NativeMethods
  {
    internal partial class NCrypt
    {
      internal enum BufferType
      {
        /// <summary>
        ///   The buffer is a key derivation function (KDF) parameter that
        ///   contains a null-terminated Unicode string that  identifies the
        ///   hash algorithm. This can be one of the standard hash algorithm
        ///   identifiers from CNG Algorithm
        ///   Identifiers or the identifier for another registered hash
        ///   algorithm.
        ///   The size specified by the cbBuffer member of this structure
        ///   must include the terminating NULL character.
        /// </summary>
        /// <remarks>
        ///   KDF_HASH_ALGORITHM
        /// </remarks>
        KdfHashAlgorithm = 0,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the value to add
        ///   to the beginning of the message input to the hash
        ///   function.
        /// </summary>
        /// <remarks>
        ///   KDF_SECRET_PREPEND
        /// </remarks>
        KdfSecretPrepend = 1,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the value to add to
        ///   the end of the message input to the hash function.
        /// </summary>
        /// <remarks>
        ///   KDF_SECRET_APPEND
        /// </remarks>
        KdfSecretAppend = 2,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the plain text value
        ///   of the HMAC key.
        /// </summary>
        /// <remarks>
        ///   KDF_HMAC_KEY
        /// </remarks>
        KdfHmacKey = 3,

        /// <summary>
        ///   The buffer is a KDF parameter that contains an ANSI string that
        ///   contains the transport layer security (TLS)
        ///   pseudo-random function (PRF) label.
        /// </summary>
        /// <remarks>
        ///   KDF_TLS_PRF_LABEL
        /// </remarks>
        KdfTlsLabel = 4,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the PRF seed value.
        ///   The seed must be 64 bytes long.
        /// </summary>
        /// <remarks>
        ///   KDF_TLS_PRF_SEED
        /// </remarks>
        KdfTlsSeed = 5,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the secret agreement
        ///   handle. The pvBuffer member contains a
        ///   BCRYPT_SECRET_HANDLE value and is not a pointer.
        /// </summary>
        /// <remarks>
        ///   KDF_SECRET_HANDLE
        /// </remarks>
        KdfSecretHandle = 6,

        /// <summary>
        ///   The buffer is a KDF parameter that contains a DWORD value
        ///   identifying the SSL/TLS protocol version whose PRF
        ///   algorithm is to be used.
        /// </summary>
        /// <remarks>
        ///   KDF_TLS_PRF_PROTOCOL
        /// </remarks>
        KdfTlsPrfProtocol = 7,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the byte array to
        ///   use as the AlgorithmID subfield of the OtherInfo
        ///   parameter to the SP 800-56A KDF.
        /// </summary>
        /// <remarks>
        ///   KDF_ALGORITHMID
        /// </remarks>
        KdfAlgorithmId = 8,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the byte array to
        ///   use as the PartyUInfo subfield of the OtherInfo
        ///   parameter to the SP 800-56A KDF.
        /// </summary>
        /// <remarks>
        ///   KDF_PARTYUINFO
        /// </remarks>
        KdfPartyUInfo = 9,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the byte array to
        ///   use as the PartyVInfo  subfield of the OtherInfo
        ///   parameter to the SP 800-56A KDF.
        /// </summary>
        /// <remarks>
        ///   KDF_PARTYVINFO
        /// </remarks>
        KdfPartyVInfo = 10,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the byte array to
        ///   use as the PartyUSuppPubInfo Info subfield of the
        ///   OtherInfo parameter to the SP 800-56A KDF.
        /// </summary>
        /// <remarks>
        ///   KDF_SUPPPUBINFO
        /// </remarks>
        KdfSuppPubInfo = 11,

        /// <summary>
        ///   The buffer is a KDF parameter that contains the byte array to
        ///   use as the SuppPrivInfo  Info subfield of the OtherInfo
        ///   parameter to the SP 800-56A KDF.
        /// </summary>
        /// <remarks>
        ///   KDF_SUPPPRIVINFO
        /// </remarks>
        KdfSuppPrivateInfo = 12,

        /// <summary>
        ///   The buffer contains the random number of the SSL client.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_SSL_CLIENT_RANDOM
        /// </remarks>
        SslClientRandom = 20,

        /// <summary>
        ///   The buffer contains the random number of the SSL server.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_SSL_SERVER_RANDOM
        /// </remarks>
        SslServerRandom = 21,

        /// <summary>
        ///   The buffer contains the highest SSL version supported.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_SSL_HIGHEST_VERSION
        /// </remarks>
        SslHighestVersion = 22,

        /// <summary>
        ///   The buffer contains the clear portion of the SSL master key.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_SSL_CLEAR_KEY
        /// </remarks>
        SslClearKey = 23,

        /// <summary>
        ///   The buffer contains the SSL key argument data.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_SSL_KEY_ARG_DATA
        /// </remarks>
        SslKeyArgData = 24,

        /// <summary>
        ///   The buffer contains a null-terminated ANSI string that contains
        ///   the PKCS object identifier.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_OID
        /// </remarks>
        PkcsOid = 40,

        /// <summary>
        ///   The buffer contains a null-terminated ANSI string that contains
        ///   the PKCS algorithm object identifier.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_ALG_OID
        /// </remarks>
        PkcsAlgOid = 41,

        /// <summary>
        ///   The buffer contains the PKCS algorithm parameters.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_ALG_PARAM
        /// </remarks>
        PkcsAlgParam = 42,

        /// <summary>
        ///   The buffer contains the PKCS algorithm identifier.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_ALG_ID
        /// </remarks>
        PkcsAlgId = 43,

        /// <summary>
        ///   The buffer contains the PKCS attributes.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_ATTRS
        /// </remarks>
        PkcsAttrs = 44,

        /// <summary>
        ///   The buffer contains a null-terminated Unicode string that
        ///   contains the key name.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_KEY_NAME
        /// </remarks>
        PkcsKeyName = 45,

        /// <summary>
        ///   The buffer contains a null-terminated Unicode string that
        ///   contains the PKCS8 password. This parameter is optional and
        ///   can be NULL.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_PKCS_SECRET
        /// </remarks>
        PkcsSecret = 46,

        /// <summary>
        ///   The buffer contains a serialized certificate store that contains
        ///   the PKCS certificate. This serialized store is obtained by using
        ///   the CertSaveStore function with the CERT_STORE_SAVE_TO_MEMORY
        ///   option.
        ///   When this property is being retrieved, you can access the
        ///   certificate store by passing this serialized store to the
        ///   CertOpenStore function with the CERT_STORE_PROV_SERIALIZED
        ///   option.
        /// </summary>
        /// <remarks>
        ///   NCRYPTBUFFER_CERT_BLOB
        /// </remarks>
        CertBlob = 47
      }
    }
  }
}