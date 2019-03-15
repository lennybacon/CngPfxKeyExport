namespace Sample
{
  partial class NativeMethods
  {
    partial class Crypt32
    {
      public enum CertificateProperty
      {
        /// <remarks>
        /// CERT_KEY_PROV_HANDLE_PROP_ID
        /// </remarks>
        CERT_KEY_PROV_HANDLE_PROP_ID = 1,
        /// <remarks>
        /// CERT_KEY_PROV_INFO_PROP_ID
        /// </remarks>
        KeyProviderInfo = 2,
        /// <remarks>
        /// CERT_SHA1_HASH_PROP_ID
        /// </remarks>
        CERT_SHA1_HASH_PROP_ID = 3, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_MD5_HASH_PROP_ID
        /// </remarks>
        CERT_MD5_HASH_PROP_ID = 4, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_HASH_PROP_ID
        /// </remarks>
        CERT_HASH_PROP_ID = CERT_SHA1_HASH_PROP_ID, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_KEY_CONTEXT_PROP_ID
        /// </remarks>
        KeyContext = 5,
        /// <remarks>
        /// CERT_KEY_SPEC_PROP_ID
        /// </remarks>
        CERT_KEY_SPEC_PROP_ID = 6,
        /// <remarks>
        /// CERT_IE30_RESERVED_PROP_ID
        /// </remarks>
        CERT_IE30_RESERVED_PROP_ID = 7,
        /// <remarks>
        /// CERT_PUBKEY_HASH_RESERVED_PROP_ID
        /// </remarks>
        CERT_PUBKEY_HASH_RESERVED_PROP_ID = 8,
        /// <remarks>
        /// CERT_ENHKEY_USAGE_PROP_ID
        /// </remarks>
        CERT_ENHKEY_USAGE_PROP_ID = 9,
        /// <remarks>
        /// CERT_CTL_USAGE_PROP_ID
        /// </remarks>
        CERT_CTL_USAGE_PROP_ID = CERT_ENHKEY_USAGE_PROP_ID,
        /// <remarks>
        /// CERT_NEXT_UPDATE_LOCATION_PROP_ID
        /// </remarks>
        CERT_NEXT_UPDATE_LOCATION_PROP_ID = 10,
        /// <remarks>
        /// CERT_FRIENDLY_NAME_PROP_ID
        /// </remarks>
        CERT_FRIENDLY_NAME_PROP_ID = 11,
        /// <remarks>
        /// CERT_PVK_FILE_PROP_ID
        /// </remarks>
        CERT_PVK_FILE_PROP_ID = 12,
        /// <remarks>
        /// CERT_DESCRIPTION_PROP_ID
        /// </remarks>
        CERT_DESCRIPTION_PROP_ID = 13,
        /// <remarks>
        /// CERT_ACCESS_STATE_PROP_ID
        /// </remarks>
        CERT_ACCESS_STATE_PROP_ID = 14,
        /// <remarks>
        /// CERT_SIGNATURE_HASH_PROP_ID
        /// </remarks>
        CERT_SIGNATURE_HASH_PROP_ID = 15,
        /// <remarks>
        /// CERT_SMART_CARD_DATA_PROP_ID
        /// </remarks>
        CERT_SMART_CARD_DATA_PROP_ID = 16,
        /// <remarks>
        /// CERT_EFS_PROP_ID
        /// </remarks>
        CERT_EFS_PROP_ID = 17,
        /// <remarks>
        /// CERT_FORTEZZA_DATA_PROP_ID
        /// </remarks>
        CERT_FORTEZZA_DATA_PROP_ID = 18,
        /// <remarks>
        /// CERT_ARCHIVED_PROP_ID
        /// </remarks>
        CERT_ARCHIVED_PROP_ID = 19,
        /// <remarks>
        /// CERT_KEY_IDENTIFIER_PROP_ID
        /// </remarks>
        CERT_KEY_IDENTIFIER_PROP_ID = 20,
        /// <remarks>
        /// CERT_AUTO_ENROLL_PROP_ID
        /// </remarks>
        CERT_AUTO_ENROLL_PROP_ID = 21,
        /// <remarks>
        /// CERT_PUBKEY_ALG_PARA_PROP_ID
        /// </remarks>
        CERT_PUBKEY_ALG_PARA_PROP_ID = 22,
        /// <remarks>
        /// CERT_CROSS_CERT_DIST_POINTS_PROP_ID
        /// </remarks>
        CERT_CROSS_CERT_DIST_POINTS_PROP_ID = 23,
        /// <remarks>
        /// CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID
        /// </remarks>
        CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID = 24, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID
        /// </remarks>
        CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID = 25, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_ENROLLMENT_PROP_ID
        /// </remarks>
        CERT_ENROLLMENT_PROP_ID = 26,
        /// <remarks>
        /// CERT_DATE_STAMP_PROP_ID
        /// </remarks>
        CERT_DATE_STAMP_PROP_ID = 27,
        /// <remarks>
        /// CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID
        /// </remarks>
        CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID = 28, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_SUBJECT_NAME_MD5_HASH_PROP_ID
        /// </remarks>
        CERT_SUBJECT_NAME_MD5_HASH_PROP_ID = 29, /*DevSkim: ignore DS126858*/
        /// <remarks>
        /// CERT_EXTENDED_ERROR_INFO_PROP_ID
        /// </remarks>
        CERT_EXTENDED_ERROR_INFO_PROP_ID = 30,
        /// <remarks>
        /// CERT_RENEWAL_PROP_ID
        /// </remarks>
        CERT_RENEWAL_PROP_ID = 64,
        /// <remarks>
        /// CERT_ARCHIVED_KEY_HASH_PROP_ID
        /// </remarks>
        CERT_ARCHIVED_KEY_HASH_PROP_ID = 65,
        /// <remarks>
        /// CERT_FIRST_RESERVED_PROP_ID
        /// </remarks>
        CERT_FIRST_RESERVED_PROP_ID = 66,
      }

    }
  }
}