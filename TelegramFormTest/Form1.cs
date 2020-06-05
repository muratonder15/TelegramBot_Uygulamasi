using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
namespace TelegramFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1158862731:AAEoIX5LN8cpJDIZ3oz9rHaSZrwQPJ2hemE");
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static string[] anahtar = new string[21];
        private void Form1_Load(object sender, EventArgs e)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            for (int i = 1; i <= 20; i++)
            {
                if (anahtar[i] == null)
                {
                    anahtar[i] = i.ToString() + "-)";
                }
            }
            //Console.ReadLine();
            //Bot.StopReceiving();
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string toplam = "";

            for (int i = 1; i <= 20; i++)
            {
                if (anahtar[i] == null)
                {
                    anahtar[i] = i.ToString() + "-)";
                }
            }
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {


//                for (int j = 1; j <= 20; j++)
//                {
//                    if (e.Message.Text == ("/cevap " + j + " a"))
//                    {
//                        //var cevap=from a in db.testlers where 
//                        anahtar[j] = anahtar[j] + " a";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:a");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " b"))
//                    {

//                        anahtar[j] = anahtar[j] + " b";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:b");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " c"))
//                    {

//                        anahtar[j] = anahtar[j] + " c";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:c");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " d"))
//                    {

//                        anahtar[j] = anahtar[j] + " d";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:d");
//                        break;
//                    }
//                    else if (e.Message.Text == ("/cevap " + j + " e"))
//                    {

//                        anahtar[j] = anahtar[j] + " e";
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:e");
//                        break;
//                    }
//                    else if (e.Message.Text == "/anahtar")
//                    {
//                        for (int i = 1; i <= 20; i++)
//                        {

//                            toplam = toplam + "\n" + anahtar[i];

//                        }
//                        Bot.SendTextMessageAsync(e.Message.Chat.Id, toplam);
//                        break;
//                    }
//                    else
//                    {

//                        if (j >= 20)
//                        {

//                            Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Kullanım : 
///cevap soru numarası harf ");
//                        }
//                    }
//                }
                
                int test_no = 1;
                //veritabanından
                for (int j = 1; j <= 20; j++)
                {
                    if (e.Message.Text == ("/cevap " + j + " a"))
                    {
                        var soru = (from a in db.testlers where a.soru_no == j && a.test_no==test_no select a).FirstOrDefault();
                        if (soru==null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.a = 1;
                            test.aktif_mi = true;
                        db.testlers.InsertOnSubmit(test);
                        db.SubmitChanges();
                        }
                        else
                        {
                            if (soru.a == null)
                                soru.a = 1;
                            else
                                soru.a += 1;
                            db.SubmitChanges();
                        }
                        
                                             
                        anahtar[j] = anahtar[j] + " a";
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:a");

                    }
                    else if (e.Message.Text == ("/cevap " + j + " b"))
                    {
                        var soru = (from a in db.testlers where a.soru_no == j && a.test_no == test_no select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.b = 1;
                            test.aktif_mi = true;
                            db.testlers.InsertOnSubmit(test);
                            db.SubmitChanges();
                        }
                        else
                        {
                            if (soru.b == null)
                                soru.b = 1;
                            else
                            soru.b += 1;
                            db.SubmitChanges();
                        }
                        anahtar[j] = anahtar[j] + " b";
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:b");

                    }
                    else if (e.Message.Text == ("/cevap " + j + " c"))
                    {
                        var soru = (from a in db.testlers where a.soru_no == j && a.test_no == test_no select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.c = 1;
                            test.aktif_mi = true;
                            db.testlers.InsertOnSubmit(test);
                            db.SubmitChanges();
                        }
                        else
                        {
                            if (soru.c == null)
                                soru.c = 1;
                            else
                                soru.c += 1;
                            db.SubmitChanges();
                        }
                        anahtar[j] = anahtar[j] + " c";
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:c");

                    }
                    else if (e.Message.Text == ("/cevap " + j + " d"))
                    {
                        var soru = (from a in db.testlers where a.soru_no == j && a.test_no == test_no select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.d = 1;
                            test.aktif_mi = true;
                            db.testlers.InsertOnSubmit(test);
                            db.SubmitChanges();
                        }
                        else
                        {
                            if (soru.d== null)
                                soru.d = 1;
                            else
                                soru.d += 1;
                            db.SubmitChanges();
                        }

                        anahtar[j] = anahtar[j] + " d";
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:d");

                    }
                    else if (e.Message.Text == ("/cevap " + j + " e"))
                    {

                        var soru = (from a in db.testlers where a.soru_no == j && a.test_no == test_no select a).FirstOrDefault();
                        if (soru == null)
                        {
                            testler test = new testler();
                            test.test_no = test_no;
                            test.soru_no = j;
                            test.e = 1;
                            test.aktif_mi = true;
                            db.testlers.InsertOnSubmit(test);
                            db.SubmitChanges();
                        }
                        else
                        {
                            if (soru.e == null)
                                soru.e = 1;
                            else
                                soru.e+= 1;
                            db.SubmitChanges();
                        }
                        anahtar[j] = anahtar[j] + " e";
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:e");

                    }
                    else if(e.Message.Text == "/anahtar")
                    {
                        for (int i = 1; i <= 20; i++)
                        {

                            toplam = toplam + "\n" + anahtar[i];

                        }
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, toplam);
                        break;
                    }
                    else
                    {

                        if (j >= 20)
                        {

                            Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Kullanım : 
                        /cevap soru numarası harf ");
                        }
                    }

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bot.StopReceiving();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string toplam = "";
            CevapListesi();
            
            
        }

        public void CevapListesi()
        {
            listBox1.Items.Clear();
            var cevap_listesi = (from a in db.testlers where a.test_no == 1 && a.aktif_mi == true orderby a.soru_no select a).ToList();


            foreach (var cevap in cevap_listesi)
            {
                int i = 1;
                string cevapa = "", cevapb = "", cevapc = "", cevapd = "", cevape = "";
                if (cevap.a != null) cevapa = "A(" + cevap.a.ToString() + ")";
                if (cevap.b != null) cevapb = "B(" + cevap.b.ToString() + ")";
                if (cevap.c != null) cevapc = "C(" + cevap.c.ToString() + ")";
                if (cevap.d != null) cevapd = "D(" + cevap.d.ToString() + ")";
                if (cevap.e != null) cevape = "E(" + cevap.e.ToString() + ")";
                listBox1.Items.Add(cevap.soru_no + "-) " +
                    cevapa +
                    cevapb +
                    cevapc +
                    cevapd +
                    cevape
                    );
                anahtar[i]=cevap.;
                i += 1;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.From.FirstName + " soru:" + j + " cevap:a");
        }
    }
}