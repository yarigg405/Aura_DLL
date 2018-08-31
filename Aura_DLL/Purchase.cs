﻿using System;
using System.Data;
using System.Globalization;


namespace Aura.Model
{
    [Serializable]
    public class Purchase
    {
        //класс, описывающий объект закупки

        public Purchase()
        {
            purchaseEisDate = bidsStartDate = bidsEndDate =
                bidsOpenDate = bidsFirstPartDate = auctionDate =
                bidsSecondPartDate = bidsFinishDate = contractDatePlan =
                contractDateLast = contractDateReal = reestrDateLast =

                DateTime.MinValue;

        }

        public Purchase(DataRow row)
        {
            //создать закупку из строки БД

            id = row[0] is DBNull ? 0 : (int)(long)row[0];
            employeID = row[1] is DBNull ? 0 : (int)(long)row[1];
            organizationID = row[2] is DBNull ? 0 : (int)(long)row[2];
            purchaseMethodID = row[3] is DBNull ? 0 : (int)(long)row[3];
            purchaseName = row[4] is DBNull ? "" : (string)row[4];
            statusID = row[5] is DBNull ? 0 : (int)(long)row[5];
            purchacePrice = row[6] is DBNull ? 0 : (float)(double)row[6];

            purchaseEisNum = row[7] is DBNull ? "" : (string)row[7];
            purchaseEisDate = ToDateTime(row[8]);
            bidsStartDate = ToDateTime(row[9]);
            bidsEndDate = ToDateTime(row[10]);
            bidsOpenDate = ToDateTime(row[11]);
            bidsFirstPartDate = ToDateTime(row[12]);
            auctionDate = ToDateTime(row[13]);
            bidsSecondPartDate = ToDateTime(row[14]);
            bidsFinishDate = ToDateTime(row[15]);

            contractPrice = row[16] is DBNull ? 0 : (float)(double)row[16];
            contractDatePlan = ToDateTime(row[17]);
            contractDateLast = ToDateTime(row[18]);
            contractDateReal = ToDateTime(row[19]);
            reestrDateLast = ToDateTime(row[20]);
            reestrNumber = row[21] is DBNull ? "" : (string)row[21];

            comments = row[22] is DBNull ? "" : (string)row[22];
            law = row[23] is DBNull ? 0 : (int)(long)row[23];
            withAZK = row[24] is DBNull ? 0 : (int)(long)row[24];
            employeDocumentationID = row[25] is DBNull ? 0 : (int)(long)row[25];
            resultOfControl = row[26] is DBNull ? "" : (string)row[26];
            protocolStatusID = row[27] is DBNull ? 0 : (int)(long)row[27];
            bidsReviewDate = ToDateTime(row[28]);
            bidsRatingDate = ToDateTime(row[29]);
            controlStatus = row[30] is DBNull ? 0 : (int)(long)row[30];
            colorMark = row[31] is DBNull ? 0 : (int)(long)row[31];

            commentsFontColor = row[32] is DBNull ? 0 : (int)(long)row[32];
            resultOfControlColor = row[33] is DBNull ? 0 : (int)(long)row[33];
            employeReestID = row[34] is DBNull ? 0 : (int)(long)row[34];
            reestrStatus = row[35] is DBNull ? 0 : (int)(long)row[35];

        }

        public int id;                      //ИД закупки в БД
        public int employeID;               //индекс юзера, ответственного за размещение
        public int organizationID;          //индекс организации - заказчика
        public int purchaseMethodID;        //индекс способа определения поставщика
        public string purchaseName;         //наименование объекта закупки
        public int statusID;                //идентификатор статуса. Подача заявок, рассмотрение итд
        public float purchacePrice;         //НМЦК, начальная цена

        public string purchaseEisNum;       //номер извещения в ЕИСе
        public DateTime purchaseEisDate;      //дата публикации извещения в ЕИС
        public DateTime bidsStartDate;        //дата начала подачи заявок
        public DateTime bidsEndDate;          //дата окончания подачи заявок
        public DateTime bidsOpenDate;         //дата вскрытия конвертов
        public DateTime bidsFirstPartDate;    //дата рассмотрения первых частей
        public DateTime auctionDate;          //дата проведения аукциона
        public DateTime bidsSecondPartDate;   //дата рассмотрения вторых частей
        public DateTime bidsFinishDate;       //дата подведения итогов

        public float contractPrice;         //цена заключенного контракта
        public DateTime contractDatePlan;     //НЕ ИСПОЛЬЗУЕТСЯ
        public DateTime contractDateLast;     //НЕ ИСПОЛЬЗУЕТСЯ
        public DateTime contractDateReal;     //дата подписания контракта (фактическая)
        public DateTime reestrDateLast;       //дата внесения контракта в реестр (фактическая)
        public string reestrNumber;         //реестровый номер контракта в ЕИС

        public string comments;             //комментарии к закупке

        /// <summary>
        /// Закон, по которой проводится процедура. 
        /// 0 - не указано,
        /// 1 - 44 ФЗ, 
        /// 2 - 223 ФЗ, 
        /// </summary>
        public int law;                     //закон, по которой проводится процедура
        public int withAZK;                 //занесена ли закупка в АЦК. 0 - занесена, 1- нет
        public int employeDocumentationID;  //ID юзера, ответственного за подготовку документации
        public string resultOfControl;      //результаты проверки
        public int protocolStatusID;        //статус протокола закупки
        public DateTime bidsReviewDate;       //дата рассмотрения заявок
        public DateTime bidsRatingDate;       //дата оценки заявок
        public int controlStatus;           //проверено или не проверено
        public int colorMark;               //цветовая отметка закупки. Берется из Color.ToArgb()

        public int commentsFontColor;       //цвет комментариев. Берется из Color.ToArgbs()
        public int resultOfControlColor;    //цвет текста результата контроля. Берется из Color.ToArgbs()
        public int employeReestID;          //ID юзера, ответственного за занесение в реест
        public int reestrStatus;            //внесено или не внесено в реестр


        private DateTime ToDateTime(object ob)
        {
            try
            {
                return DateTime.ParseExact((string)ob, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            catch
            {
                return DateTime.MinValue;
            }
        }

    }

}
