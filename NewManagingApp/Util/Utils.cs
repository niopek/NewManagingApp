namespace NewManagingApp.Util;

internal static class Utils
{
    public static List<int> FindIndeksFromText(string text)
    {
        List<int> list = new();

        string tempString = "";

        foreach (char c in text)
        {
            if (Char.IsAsciiDigit(c))
            {
                tempString += c;

                if (tempString.Length == 7)
                {
                    list.Add(int.Parse(tempString));
                    tempString = "";
                }
            }
            else
            {
                tempString = "";
            }

        }

        return list;
    }

    public static bool IsTextBoxEmpty(string text)
    {
        if (text == null || text == "")
            return true;

        return false;
    }


    public static string ClearDotsFromPrice(string str)
    {
        string newStr = "";

        foreach (char c in str)
        {
            if (Char.IsDigit(c) || c == ',')
            {
                newStr += c;
            }
        }

        return newStr;

    }

    public static string ClearHoursFromDate(string str)
    {
        string newStr = "";

        if (str.Length > 10)
        {
            for (int i = 0; i < 10; i++)
            {
                newStr += str[i];
            }
        }
        return newStr;
    }

    public static bool IsNumberInList(Plant number, ObservableCollection<Plant> listofnumers)
    {
        bool test = listofnumers.Where(l => l.PlantId == number.PlantId).Any();

        return test;
    }

    public static bool IsIndeksCreated(Order o, ObservableCollection<IndeksDetails> listI)
    {
        bool test = listI.Where(l => l.IndeksId == o.IndeksId).Any();
        return test;
    }

}
