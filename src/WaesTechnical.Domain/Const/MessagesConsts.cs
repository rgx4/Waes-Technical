using System;
using System.Collections.Generic;
using System.Text;

namespace WaesTechnical.Domain.Const
{
    public class MessagesConsts
    {
        public const string UNEXPECTED_ERROR_MESSAGE = "An unexpected error has occurred";
        public const string SUCCESSFULLY_CREATED_MESSAGE = "Data successfully inserted";
        public const string DATA_NOT_EQUAL_LENGTH_MESSAGE = "The data has different length";
        public const string DATA_EQUAL_MESSAGE = "The two data are equal";
        public const string DATA_HAVE_DIFFERENCES_MESSAGE = "The data are of the same length but have differences";
        public const string DATA_WITHOUT_VALUE_MESSAGE = "The data must have a value";
        public const string ID_WITH_VALUE_MESSAGE = "This ID already have data in the selected side";
        public const string NOT_VALID_BAS64_DATA_MESSAGE = "The data is not Base64";
    }
}
