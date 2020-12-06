using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVPZ.Models
{
    [Serializable]
    [BindProperties(SupportsGet = true)]
    public class SRS
    {      
        public SRS()
        {
            Trs = new bool[7];
            Crs = new bool[3];
            Prs = new bool[3];
            Mrs = new bool[5];

            Tr = new bool[11];
            Cr = new bool[9];
            Pr = new bool[11];
            Mr = new bool[16];


            AllRiskDescr = new List<string>();
            AllRiskDescr.AddRange(TechRiskEvent);
            AllRiskDescr.AddRange(CostRiskEvent);
            AllRiskDescr.AddRange(PlanRiskEvent);
            AllRiskDescr.AddRange(ManageRiskEvent);

            int size = AllRiskDescr.Count;
            

            var random = new Random();
            LRERp = new double[size];
            ELRERp = new double[size];
            AllRiskPer = new List<double[]>();
            AllRiskPer2 = new List<double[]>();
            for (int i = 0; i < AllRiskDescr.Count; ++i)
            {
                AllRiskPer.Add(new double[10]);
                AllRiskPer2.Add(new double[10]);

                LRERp[i] = random.Next(0, 101) / 100.0;
                ELRERp[i] = random.Next(0, 101) / 100.0;
                for (int j = 0; j < 10; ++j)
                {
                    AllRiskPer[i][j]=random.Next(0, 101) / 100.0;
                    AllRiskPer2[i][j] = random.Next(0, 101) / 100.0;
                }
            }
            EVERp = new string[size];
            
            
        }
        #region Ідентифікація ризиків розроблення ПЗ
        public bool[] Trs { get; set; }
        public bool[] Crs { get; set; }
        public bool[] Prs { get; set; }
        public bool[] Mrs { get; set; }
        public double TCrs {
            get
            {
                double res = 0;
                foreach(var val in Trs)
                {
                    res += val ? 1 : 0;
                }
                return res/18;
            }}
        public double CCrs
        {
            get
            {
                double res = 0;
                foreach (var val in Crs)
                {
                    res += val ? 1 : 0;
                }
                return res / 18;
            }
        }
        public double PCrs
        {
            get
            {
                double res = 0;
                foreach (var val in Prs)
                {
                    res += val ? 1 : 0;
                }
                return res / 18;
            }
        }
        public double MCrs
        {
            get
            {
                double res = 0;
                foreach (var val in Mrs)
                {
                    res += val ? 1 : 0;
                }
                return res / 18;
            }
        }
        public double sumRrs { get { return TCrs + CCrs + PCrs + MCrs; } }
        public string[] TechRiskSource
        {
            get
            {
                return new string[]
                {
                    "функціональні характеристики ПЗ",
                    "характеристики якості ПЗ",
                    "характеристики надійності ПЗ",
                    "застосовність ПЗ",
                    "часова продуктивність ПЗ",
                    "супроводжуваність ПЗ",
                    "повторне використання компонент ПЗ"
                };
            }
        }
        public string[] CostRiskSource
        {
            get
            {
                return new string[]
                {
                    "обмеження сумарного бюджету на програмний проект",
                    "недоступна вартість реалізації програмного проекту",
                    "низька ступінь реалізму при оцінюванні витрат на програмний проект"
                };
            }
        }
        public string[] PlanRiskSource
        {
            get
            {
                return new string[]
                {
                    "властивості та можливості гнучкості внесення змін до планів життєвого циклу розроблення ПЗ",
                    "можливості порушення встановлених термінів реалізації етапів життєвого циклу розроблення ПЗ",
                    "низька ступінь реалізму при встановленні планів і етапів життєвого циклу розроблення ПЗ"
                };
            }
        }
        public string[] RealizationManageRiskSource
        {
            get
            {
                return new string[]
                {
                    "хибна стратегія реалізації програмного проекту",
                    "неефективне планування проекту розроблення ПЗ",
                    "неякісне оцінювання програмного проекту",
                    "прогалини в документуванні етапів реалізації програмного проекту",
                    "промахи в прогнозуванні результатів реалізації програмного проекту"
                };
            }
        }
        #endregion
        #region Ідентифікація потенційних ризикових подій 
        public bool[] Tr { get; set; }
        public bool[] Cr { get; set; }
        public bool[] Pr { get; set; }
        public bool[] Mr { get; set; }
        public double TCr
        {
            get
            {
                double res = 0;
                foreach (var val in Tr)
                {
                    res += val ? 1 : 0;
                }
                return res / AllRiskDescr.Count;
            }
        }
        public double CCr
        {
            get
            {
                double res = 0;
                foreach (var val in Cr)
                {
                    res += val ? 1 : 0;
                }
                return res / AllRiskDescr.Count;
            }
        }
        public double PCr
        {
            get
            {
                double res = 0;
                foreach (var val in Pr)
                {
                    res += val ? 1 : 0;
                }
                return res / AllRiskDescr.Count;
            }
        }
        public double MCr
        {
            get
            {
                double res = 0;
                foreach (var val in Mr)
                {
                    res += val ? 1 : 0;
                }
                return res / AllRiskDescr.Count;
            }
        }
        public double sumRPs { get { return TCr + CCr + PCr + MCr; } }
        public string[] TechRiskEvent
        {
            get
            {
                return new string[]
                {
                    "затримки у постачанні обладнання, необхідного для підтримки процесу розроблення ПЗ",
                    "затримки у постачанні інструментальних засобів, необхідних для підтримки процесу розроблення ПЗ",
                    "небажання команди виконавців ПЗ використовувати інструментальні засоби для підтримки процесу розроблення ПЗ",
                    "відмова команди виконавців від CASE-засобів розроблення ПЗ",
                    "формування запитів на більш потужні інструментальні засоби розроблення ПЗ",
                    "недостатня продуктивність баз(и) даних для підтримки процесу розроблення ПЗ",
                    "програмні компоненти, які використовують повторно в ПЗ, мають дефекти та обмежені функціональні можливості",
                    "неефективність програмного коду, згенерованого CASE-засобами розроблення ПЗ",
                    "неможливість інтеграції CASE-засобів з іншими інструментальними засобами для підтримки процесу розроблення ПЗ",
                    "швидкість виявлення дефектів у програмному коді є нижчою від раніше запланованих термінів",
                    "поява дефектних системних компонент, які використовують для розроблення ПЗ"
                };
            }
        }
        public string[] CostRiskEvent
        {
            get
            {
                return new string[]
                {
                    "недооцінювання витрат на реалізацію програмного проекту (надмірно низька вартість)",
                    "переоцінювання витрат на реалізацію програмного проекту (надмірно висока вартість)",
                    "фінансові ускладнення у компанії-замовника ПЗ",
                    "фінансові ускладнення у компанії-розробника ПЗ",
                    "збільшення бюджету програмного проекта з ініціативи компанії-розробника ПЗ під час його реалізації",
                    "збільшення бюджету програмного проекта з ініціативи компанії-розробника ПЗ під час його реалізації",
                    "висока вартість виконання повторних робіт, необхідних для зміни вимог до ПЗ",
                    "реорганізація структурних підрозділів у компанії-замовника ПЗ",
                    "реорганізація команди виконавців у компанії-розробника ПЗ"
                };
            }
        }
        public string[] PlanRiskEvent
        {
            get
            {
                return new string[]
                {
                    "зміни графіка виконання робіт з боку замовника чи виконавця",
                    "порушення графіка виконання робіт у компанії-розробника ПЗ",
                    "потреба зміни користувацьких вимог до ПЗ з боку компанії-замовника ПЗ",
                    "потреба зміни функціональних вимог до ПЗ з боку компанії-розробника ПЗ",
                    "потреба виконання великої кількості повторних робіт, необхідних для зміни вимог до ПЗ",
                    "недооцінювання тривалості етапів реалізації програмного проекту з боку компанії-розробника ПЗ",
                    "переоцінювання тривалості етапів реалізації програмного проекту",
                    "остаточний розмір ПЗ перевищує заплановані його характеристики",
                    "остаточний розмір ПЗ значно менший за планові його характеристики",
                    "поява на ринку аналогічного ПЗ до виходу замовленого",
                    "поява на ринку більш конкурентоздатного ПЗ",
                };
            }
        }
        public string[] ManageRiskEvent
        {
            get
            {
                return new string[]
                {
                    "низький моральний стан персоналу команди виконавців ПЗ",
                    "низька взаємодія між членами команди виконавців ПЗ",
                    "пасивність керівника (менеджера) програмного проекту",
                    "недостатня компетентність керівника (менеджера) програмного проекту",
                    "незадоволеність замовника результатами етапів реалізації програмного проекту",
                    "недостатня кількість фахівців у команді виконавців ПЗ з необхідним професійним рівнем",
                    "хвороба провідного виконавця в найкритичніший момент розроблення ПЗ",
                    "одночасна хвороба декількох виконавців підчас розроблення ПЗ",
                    "неможливість організації необхідного навчання персоналу команди виконавців ПЗ",
                    "зміна пріоритетів у процесі управління програмним проектом",
                    "недооцінювання необхідної кількості розробників (підрядників і субпідрядників) на етапах життєвого циклу розроблення ПЗ",
                    "переоцінювання необхідної кількості розробників (підрядників і субпідрядників) на етапах життєвого циклу розроблення ПЗ",
                    "надмірне документування результатів на етапах реалізації програмного проекту",
                    "недостатнє документування результатів на етапах реалізації програмного проекту",
                    "нереалістичне прогнозування результатів на етапах реалізації програмного проекту",
                    "недостатній професійний рівень представників від компанії-замовника ПЗ"
                };
            }
        }
        #endregion
        #region  Ймовірності настання ризикових подій, встановлені експертами
        public double[] ERp {
            get 
            {
                int size = AllRiskDescr.Count;
                double[] erp = new double[size];
                for(int i = 0; i < size; ++i)
                {
                    erp[i] = 0;
                    for(int j = 0; j < 10; ++j)
                    {
                        erp[i]+= AllRiskPer[i][j]/10.0;
                    }
                }
                return erp;
            } 
        }
        public double ERpSum { get { return ERp.Sum(); } }
        public List<double[]> AllRiskPer { get; set; }
        public List<string> AllRiskDescr { get; set; }
        public double pTCr
        {
            get
            {
                if (ERpSum == 0)
                    return 0;
                double res = 0;
                for (int i = 0; i < 11; ++i)
                {
                    res += ERp[i];
                }
                return res / ERpSum;
            }
        }
        public double pCCr
        {
            get
            {
                if (ERpSum == 0)
                    return 0;
                double res = 0;
                for (int i = 11; i < 19; ++i)
                {
                    res += ERp[i];
                }
                return res / ERpSum;
            }
        }
        public double pPCr
        {
            get
            {
                if (ERpSum == 0)
                    return 0;
                double res = 0;
                for (int i = 19; i < 30; ++i)
                {
                    res += ERp[i];
                }
                return res / ERpSum;
            }
        }
        public double pMCr
        {
            get
            {
                if (ERpSum == 0)
                    return 0;
                double res = 0;
                for (int i = 30; i < 46; ++i)
                {
                    res += ERp[i];
                }
                return res / ERpSum;
            }
        }
        public double sumPRPs { get { return pTCr + pCCr + pPCr + pMCr; } }
        public double[] LRERp { get; set; }
        public double[] VRERp { 
            get 
            {
                int size = AllRiskDescr.Count;
                double[] vrerP = new double[size];
                for (int i = 0; i < size; ++i)
                {
                    vrerP[i] = LRERp[i]* ERp[i];
                }
                return vrerP;
            } 
        }
        public double maxVRER
        {
            get
            {
                return VRERp.Max();
            }
        }
        public double minVRER
        {
            get
            {
                return VRERp.Min();
            }
        }
        public double mpr
        {
            get
            {
                return (maxVRER - minVRER) / 3;
            }
        }
        #endregion
        #region  Планування ризиками
        public string[] EVERp { get; set; }
        public string[] EVMeasures
        {
            get
            {
                return new string[]
                {
                    "попереднє навчання членів проектного колективу",
                    "узгодження детального переліку вимог до ПЗ із замовником",
                    "внесення узгодженого переліку вимог до ПЗ замовника в договір",
                    "точне слідування вимогам замовника з узгодженого переліку вимог до ПЗ",
                    "попередні дослідження ринку",
                    "експертна оцінка програмного проекту досвідченим стороннім консультантом",
                    "консультації досвідченого стороннього консультанта",
                    "тренінг з вивчення необхідних інструментів розроблення ПЗ",
                    "укладання договору страхування",
                    "використання \"шаблонних\" рішень з вдалих попередніх проектів при управлінні програмним проектом",
                    "підготовка документів, які показують важливість даного проекту для досягнення фінансових цілей компанії-розробника",
                    "реорганізація роботи проектного колективу так, щоб обов'язки та робота членів колективу перекривали один одного",
                    "придбання (замовлення) частини компонент розроблюваного ПЗ",
                    "заміна потенційно дефектних компонент розроблюваного ПЗ придбаними компонентами, які гарантують якість виконання роботи",
                    "придбання більш продуктивної бази даних",
                    "використання генератора програмного коду",
                    "реорганізація роботи проектного колективу залежно від рівня труднощів виконання завдань та професійних рівнів розробників",
                    "повторне використання придатних компонент ПЗ, які були розроблені для інших програмних проектів",
                    "аналіз доцільності розроблення даного ПЗ"
                };
            }
        }
        #endregion
        #region Моніторинг ризиків
        public List<double[]> AllRiskPer2 { get; set; }//оцінки експертів
        public double[] ELRERp { get; set; }//збитки
        public double[] ERPER
        {
            get
            {
                int size = AllRiskPer2.Count;
                double[] erp = new double[size];
                for (int i = 0; i < size; ++i)
                {
                    erp[i] = 0;
                    for (int j = 0; j < 10; ++j)
                    {
                        erp[i] += AllRiskPer2[i][j] / 10.0;
                    }
                }
                return erp;
            }
        }
        public double[] EVRER
        {
            get
            {
                int size = AllRiskDescr.Count;
                double[] vrerP = new double[size];
                for (int i = 0; i < size; ++i)
                {
                    vrerP[i] = ERPER[i] * ELRERp[i];
                }
                return vrerP;
            }
        }
        public double ERpSum2 { get { return ERPER.Sum(); } }

        public double pTCr2
        {
            get
            {
                if (ERpSum2 == 0)
                    return 0;
                double res = 0;
                for (int i = 0; i < 11; ++i)
                {
                    res += ERPER[i];
                }
                return res / ERpSum2;
            }
        }
        public double pCCr2
        {
            get
            {
                if (ERpSum2 == 0)
                    return 0;
                double res = 0;
                for (int i = 11; i < 19; ++i)
                {
                    res += ERPER[i];
                }
                return res / ERpSum2;
            }
        }
        public double pPCr2
        {
            get
            {
                if (ERpSum2 == 0)
                    return 0;
                double res = 0;
                for (int i = 19; i < 30; ++i)
                {
                    res += ERPER[i];
                }
                return res / ERpSum2;
            }
        }
        public double pMCr2
        {
            get
            {
                if (ERpSum2== 0)
                    return 0;
                double res = 0;
                for (int i = 30; i < 46; ++i)
                {
                    res += ERPER[i];
                }
                return res / ERpSum2;
            }
        }
        public double sumPRPs2 { get { return pTCr2 + pCCr2 + pPCr2 + pMCr2; } }
        
        
        public double maxVRER2
        {
            get
            {
                return EVRER.Max();
            }
        }
        public double minVRER2
        {
            get
            {
                return EVRER.Min();
            }
        }
        public double mpr2
        {
            get
            {
                return (maxVRER2 - minVRER2) / 3;
            }
        }
        #endregion
    }
}
