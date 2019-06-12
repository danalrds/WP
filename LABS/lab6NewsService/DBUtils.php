<?php


class DBUtils
{
    private $host = '127.0.0.1';
    private $db = 'news_service';
    private $user = 'root';
    private $pass = '';
    private $charset = 'utf8';

    private $pdo;
    private $error;

    public function __construct()
    {
        $dsn = "mysql:host=$this->host;dbname=$this->db;charset=$this->charset";
        $opt = array(PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
            PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
            PDO::ATTR_EMULATE_PREPARES => false);
        try {
            $this->pdo = new PDO($dsn, $this->user, $this->pass, $opt);
        } // Catch any errors
        catch (PDOException $e) {
            $this->error = $e->getMessage();
            echo "Error connecting to DB: " . $this->error;
        }
    }

    public function getFilteredNews($category, $startDate, $endDate)
    {
        $stmt=null;
        if (($category != null) and ($startDate != null) and ($endDate != null)) {
            $stmt = $this->pdo->prepare("SELECT * FROM news n INNER JOIN categories c WHERE n.cid=c.id AND c.cname=? AND n.date BETWEEN ? AND ?;");
            $stmt->bindParam(1, $category);
            $stmt->bindParam(2, $startDate);
            $stmt->bindParam(3, $endDate);
        } else
            if ($category != null) {
                $stmt = $this->pdo->prepare("SELECT * FROM news n INNER JOIN categories c WHERE n.cid=c.id AND c.cname=?");
                $stmt->bindParam(1, $category);
            } else
                if (($startDate != null) and ($endDate != null)) {
                    $stmt = $this->pdo->prepare("SELECT * FROM news n INNER JOIN categories c WHERE n.cid=c.id AND n.date BETWEEN ? AND ?");
                    $stmt->bindParam(1, $startDate);
                    $stmt->bindParam(2, $endDate);
                }
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getProducerFromTitle($title)
    {
        $stmt = $this->pdo->prepare("SELECT u.username FROM Users u INNER JOIN News n WHERE n.producer=u.id AND n.title=?");
        $stmt->bindParam(1, $title);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }


    public function getCategoryFromNews($title, $userId)
    {
        $stmt = $this->pdo->prepare("SELECT cid FROM News where title=? AND producer=$userId");
        $stmt->bindParam(1, $title);
        $stmt->bindParam(2, $userId);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function selectNews()
    {
        $stmt = $this->pdo->query("SELECT * FROM News");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function selectCategories()
    {
        $stmt = $this->pdo->query("SELECT * FROM Categories");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getIdOfUser($username)
    {
        $stmt = $this->pdo->query("SELECT id FROM Users WHERE username='$username'");
        $res = $stmt->fetchAll(PDO::FETCH_ASSOC);
        return $res;
    }

    public function getNameOfUser($id)
    {
        $stmt = $this->pdo->query("SELECT username FROM Users WHERE id='$id'");
        $res = $stmt->fetchAll(PDO::FETCH_ASSOC);
        return $res;
    }

    public function getIdOfCategory($category)
    {
        $stmt = $this->pdo->query("SELECT id FROM Categories WHERE cname='$category'");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getNameOfCategory($id)
    {
        $stmt = $this->pdo->query("SELECT cname FROM Categories WHERE id='$id'");
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function selectUser($username, $password)
    {
        $stmt = $this->pdo->prepare("SELECT * FROM users where username= ? AND password= ?");
        $stmt->bindParam(1, $username);
        $stmt->bindParam(2, $password);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function addNews($title, $text, $producer, $date, $cid)
    {
        $statement = $this->pdo->prepare("INSERT into News(text,title,date,cid,producer) VALUES (?,?,?,?,?)");
        $statement->bindParam(1, $text);
        $statement->bindParam(2, $title);
        $statement->bindParam(3, $date);
        $statement->bindParam(4, $cid);
        $statement->bindParam(5, $producer);
        $affected_rows = $statement->execute();
        return $affected_rows;
    }

    public function updateNews($title, $text, $producer, $date, $cid)
    {
        $statement = $this->pdo->prepare("UPDATE News SET text=?, date=? WHERE title=? AND producer=? AND cid=?");
        $statement->bindParam(1, $text);
        $statement->bindParam(2, $date);
        $statement->bindParam(3, $title);
        $statement->bindParam(4, $producer);
        $statement->bindParam(5, $cid);
        $affected_rows = $statement->execute();
        return $affected_rows;
    }

    public function delete($id)
    {
        $affected_rows = $this->pdo->exec("DELETE from table where id=" . $id);
        return $affected_rows;
    }

    public function update($id, $value)
    {
        $affected_rows = $this->pdo->exec("UPDATE table SET field='" . $value . "' where id=" . $id);

    }
}


?>

