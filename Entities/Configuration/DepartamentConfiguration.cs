using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model.DepartamentsModel;

namespace Entities.Configuration
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.HasData(
                new Departament { id = 1, title = "Rektor", parent_id = 0, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 1 },
                    new Departament { id = 2, title = "Rektorning birinchi o'rinbosari (xorijiy mutaxasis)", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                    new Departament { id = 3, title = "Universitetdagi istiqbolli va strategik vazifalarni amalga oshirish masalalari bo'yicha rektor maslahatchisi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 3 },
                    new Departament { id = 4, title = "Talabalar orasida ijtimoiy ma'naviy muhit barqarorligini ta'minlashga mas'ul bo'lgan rektor maslahatchisi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 3 },
                    new Departament { id = 5, title = "Kuzatuv kengashi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },
                    new Departament { id = 6, title = "Jamoatchilik kengashi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },


                    new Departament { id = 7, title = "Universitet kengashi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },
                    new Departament { id = 63, title = "Birinchi bo'lim", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 64, title = "Ta'lim sifatini nazorat qilish bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 65, title = "Ichki audit va moliyaviy nazorat xizmati", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 20 },
                    new Departament { id = 66, title = "Korrupsiyaga qarshi kurashish \"Komplaens - nazorat\" tizimini boshqarish bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 67, title = "OTM kengashi kotibi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 21 },
                    new Departament { id = 69, title = "Rektor yordamchisi - protokol xizmati", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 20 },
                    new Departament { id = 70, title = "Yuriskonsult", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 23 },
                    new Departament { id = 71, title = "Matbuot xizmati", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 20 },
                    new Departament { id = 72, title = "Inson resurslarini boshqarish bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 73, title = "Jismomniy va yuridik shaxslarning murojaatlari bilan ishlash, nazorat va monitoring bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 74, title = "Devonxona", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 24 },
                    new Departament { id = 75, title = "Arxiv", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 25 },
                    new Departament { id = 76, title = "Xalqaro rwytinglar bilan ishlash bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                    new Departament { id = 77, title = "Raqamli transformatsiya bo'limi", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },


                    new Departament { id = 8, title = "Akademik faoliyat bo'yicha prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 14, title = "Akademik faoliyati boshqarmasi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 5 },
                        new Departament { id = 15, title = "Raqamli ta'lim texnologiyalari markazi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                        new Departament { id = 16, title = "Axborot - resurs markazi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                        new Departament { id = 17, title = "Tahririy nashriyoti va poligrafiya bo'limi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 18, title = "Magistratura bo'limi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 19, title = "Sirtqi bo'lim", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 20, title = "O'quv ishlari bo'yicha assistent", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 8 },
                        new Departament { id = 21, title = "Talabalarga xizmat ko'rsatish markazi (Ofis registrator)", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                            new Departament { id = 26, title = "Akademik mobillilikni muvofiqlashtirish va talabalar registratsiyasi (admission ofisi) sektori", parent_id = 21, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 11 },
                            new Departament { id = 27, title = "Talabalar bilan ishlash sektori", parent_id = 21, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 11 },
                            new Departament { id = 28, title = "Ikkinchi bo'lim", parent_id = 21, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                            new Departament { id = 29, title = "Talabalarni turar joy bilan ta'minlash ishlarini muvofiqlashtiruvchi bo'lim", parent_id = 21, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 22, title = "Akademik litsey", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 9 },
                        new Departament { id = 23, title = "Andijon transport texnikumi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 10 },
                        new Departament { id = 24, title = "Samarqand temir yo'l texnikumi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 10 },
                        new Departament { id = 25, title = "Nukus transport texnikumi", parent_id = 8, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 10 },





                    new Departament { id = 9, title = "Yoshlar masalalari va ma'naviy - ma'rifiy ishlar bo'yicha birinchi prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 30, title = "Yoshlar bilan ishlash, ma'naviy - ma'rifat bo'limi", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 31, title = "Muzey", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 14 },
                        new Departament { id = 32, title = "Psixolog", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 15 },
                        new Departament { id = 33, title = "Sport inshootlari", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 16 },
                        new Departament { id = 34, title = "Xotin - qizlar maslahat kengashi", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },
                        new Departament { id = 35, title = "TTJ (administratsiya va ishchi xodimlar)", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 18 },
                        new Departament { id = 36, title = "Talabalar kengashi", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },
                        new Departament { id = 37, title = "Yoshlar ittifoqi", parent_id = 9, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },




                    new Departament { id = 10, title = "Ilmiy ishlar va innovatsiyalar bo'yicha prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 38, title = "Ilmiy - tadqiqotlar, innovatsiyalar va ilmiy - pedagofik kadrlar tayyorlash bo'limi", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 39, title = "Iqtidorli talabalarning ilmiy - tadqiqit faoliyatini tashkil etish bo'limi", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 40, title = "Ilmiy - innovatsion va loyiha - konstruktorlik bo'limi", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 41, title = "Ilmiy nashrlar bilan ishlash bo'limi", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 42, title = "Ixtisoslashtirilgan ilmiy kengashlar", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 4 },
                        new Departament { id = 43, title = "Ilmiy - innovatsion ishlanmalarni tijoratlashtirish bo'limi", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 44, title = "Ilmiy - tadqiqot markazlari", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                        new Departament { id = 45, title = "Tadqiqot ishlari bo'yicha assistent", parent_id = 10, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 8 },




                    new Departament { id = 11, title = "Xalqaro hamkorlik bo'yicha prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 46, title = "Xalqaro hamkorlik boshqarmasi", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 5 },
                        new Departament { id = 47, title = "Akademik mobillik va xorijiy grantlar va institutlar bilan ishlash bo'limi", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 48, title = "Xalqaro ta'lim dasturlari bilan ishlash bo'limi", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 49, title = "O'zbekiston - Turkiya hamkorlik markazi", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                        new Departament { id = 50, title = "\"Language Club\" Xorijiy tillar markazi", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },
                        new Departament { id = 51, title = "Xorij bilan hamkorlik markazlari", parent_id = 11, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 },



                    new Departament { id = 12, title = "Moliya - iqtisod ishlari bo'yicha prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 52, title = "Moliyalashtirish, buxgalteriya hisobi, hisoboti va tahlili bo'limi - Bosh hisobchi", parent_id = 12, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 53, title = "Ishlar boshqarmasi", parent_id = 12, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 5 },
                            new Departament { id = 56, title = "Xo'jalik bo'limi", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                            new Departament { id = 57, title = "Texnik ta'mirlash va tezkor qayta tiklash bo'limi", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                            new Departament { id = 58, title = "Fuqaro va mehnat muhofazasi bo'limi", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                            new Departament { id = 59, title = "Qozonxona", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 19 },
                            new Departament { id = 60, title = "Transport xizmati bo'limi", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                            new Departament { id = 61, title = "Xavfsizlik xizmati bo'limi", parent_id = 53, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 7 },
                        new Departament { id = 54, title = "O'quv amaliyot poligoni", parent_id = 12, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 12 },
                        new Departament { id = 55, title = "Omborxona", parent_id = 12, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 13 },



                    new Departament { id = 13, title = "Ishlab chiqarish korxonalar bilan integratsiya bo'yicha prorektor", parent_id = 1, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 2 },
                        new Departament { id = 62, title = "Karera markazi", parent_id = 13, status_id = 1, crated_at = DateTime.UtcNow, departament_type_id = 6 }



                );

        }
    }
}
