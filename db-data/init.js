db = db.getSiblingDB("ScoreKeeperDb");
db.article.drop();

db.article.save({
    title: "title"   
});
