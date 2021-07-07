using BusinessLogicLayer;
using DataTransferObject;
using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetListActorsByIdFilm()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE GetListActorsByIdFilm
                var al = bllmanager.GetListActorsByIdFilm(13);
                foreach (LightActorDTO a in al)
                {
                    if (a != null)
                    {
                        Console.WriteLine("TestGetListActorsByIdFilm : PASS");
                        Assert.Pass();
                    }
                    else
                        Assert.Fail();
                }
            }
        }

        [Test]
        public void GetListFilmTypesByIdFilm()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE GetListFilmTypesByIdFilm
                var al = bllmanager.GetListFilmTypesByIdFilm(13);
                foreach (FilmTypeDTO ft in al)
                {
                    if (ft != null)
                    {
                        Console.WriteLine("GetListFilmTypesByIdFilm : PASS");
                        Assert.Pass();
                    }
                    else
                        Assert.Fail();
                }
            }
        }

        [Test]
        public void FindListFilmByPartialActorName()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE FindListFilmByPartialActorName
                var temp = bllmanager.FindListFilmByPartialActorName("Wright", 100);

                foreach (FilmDTO f in temp)
                {
                    if (f != null)
                    {
                        Console.WriteLine("FindListFilmByPartialActorName : PASS");
                        Assert.Pass();
                    }
                    else
                        Assert.Fail();
                }
            }
        }

        [Test]
        public void GetFavoriteActors()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE GetFavoriteActors
                var tmp = bllmanager.GetFavoriteActors(10, 300);

                foreach (ActorDTO a in tmp)
                {
                    if (a != null)
                    {
                        Console.WriteLine("GetFavoriteActors : PASS");
                        Assert.Pass();
                    }
                    else
                        Assert.Fail();
                }
            }
        }

        [Test]
        public void GetFullFilmDetailsByIdFilm()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE GetFullFilmDetailsByIdFilm
                var tmp = bllmanager.GetFullFilmDetailsByIdFilm(13);
                if (tmp != null)
                {
                    Console.WriteLine("GetFullFilmDetailsByIdFilm : PASS");
                    Assert.Pass();
                }
                else
                    Assert.Fail();
            }
        }

        [Test]
        public void InsertCommentOnFilmId()
        {
            using (BllManager bllmanager = new BllManager())
            {
                // TEST DE InsertCommentOnFilmId
                int nbcommentbefore = bllmanager.GetFullFilmDetailsByIdFilm(13).Comments.Count;
                bllmanager.InsertCommentOnFilmId(13, new CommentDTO("Super Film !", 4, "Olivier", new DateTime()));
                var f = bllmanager.GetFullFilmDetailsByIdFilm(13);
                if(f.Comments.Count == ++nbcommentbefore)
                {
                    Console.WriteLine("InsertCommentOnFilmId : PASS");
                    Assert.Pass();
                }
                else
                    Assert.Fail();
            }
        }




        












    }
}