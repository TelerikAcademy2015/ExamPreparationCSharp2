using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodeAndEncrypt
{
    static void Main()
    {
        string text = Console.ReadLine();
        string cypher = Console.ReadLine();
        //Console.WriteLine(Encrypt(text, cypher));
        Console.WriteLine(Encode(Encrypt(text, cypher), cypher));
    }

    static string Encrypt(string message, string cypher)
    {
        StringBuilder sb = new StringBuilder();
        if (message.Length > cypher.Length)
        {
            char code = ' ';
            for (int i = 0; i < message.Length; i++)
            {
                code = (char)(((message[i] - 'A') ^ (cypher[i % cypher.Length] - 'A')) + 'A');
                sb.Append(code);
            }
        }
        else
        {
            char code = ' ';
            for (int i = 0; i < message.Length; i++)
            {
                int cypherIndex = message.Length + i;
                char secondEncryptChar = ' ';
                if (cypherIndex > cypher.Length - 1)
                {
                    secondEncryptChar = 'A';
                }
                else
                {
                    secondEncryptChar = cypher[cypherIndex];
                }
                code = (char)((((message[i] - 'A') ^ (cypher[i] - 'A')) ^ (secondEncryptChar - 'A')) + 'A');
                sb.Append(code);
            }

        }
        return sb.ToString();
    }

    static string Encode(string text, string chyper)
    {
        var stb = new StringBuilder();
        var newText = new StringBuilder();
        newText.Append(text).Append(chyper);
        int counter = 1;
        char currentLetter = ' ';
        for (int i = 0; i <= newText.Length - 1; i++)
        {
            if (i == newText.Length - 1)
            {
                if (counter > 2)
                {
                    stb.Append(counter);
                    stb.Append(currentLetter);
                    counter = 1;
                }
                else
                {
                    if (counter == 2)
                    {
                        stb.Append(newText[i]);
                        stb.Append(newText[i - 1]);
                        counter = 1;
                    }
                    else
                    {
                        stb.Append(newText[i]);
                        counter = 1;
                    }

                }

            }
            else
            {
                if ((newText[i] == newText[i + 1]))
                {
                    counter++;
                    currentLetter = newText[i];
                }
                else
                {
                    if (counter > 2)
                    {
                        stb.Append(counter);
                        stb.Append(currentLetter);
                        counter = 1;
                    }
                    else
                    {
                        if (counter == 2)
                        {
                            stb.Append(newText[i]);
                            stb.Append(newText[i-1]);
                            counter = 1;
                        }
                        else
                        {
                            stb.Append(newText[i]);
                            counter = 1;
                        }

                    }

                }    
            }
      
        }

        return stb.Append(chyper.Length).ToString();
    }
}

