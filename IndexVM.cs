using AllittaMMC.Models;
using System.Collections.Generic;


namespace AllittaMMC
{
    public class IndexVM
    {
        public TourPacket tour { get; set; }
        public List<TourPacket> tourPackets { get; set; }
        public Contact contact { get; set; }
        public List<Contact> contacts { get; set; }
        public List<Additional_Info> additional_Infos { get; set; }
        public List<Hotel> hotels { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<Travel> travels { get; set; }
        public List<Slide> slides { get; set; }
        public int sp_ID { get; set; }
        public AboutU about { get; set; }
        public List<HomeSlide> homeSlides { get ; set; }
        public List<Service> xidmetlers { get; set; }
        public List<ServicesHeader> xidmetlerBasliqs { get; set; }
        public List<OurTeam> ourTeams { get; set; }
        public List<Transfer> transfers { get; set; }
    }
}