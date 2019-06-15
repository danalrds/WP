package utils;

public class Question {
    private Integer id;
    private Integer testId;
    private String question;
    private String correct;
    private String wrong;

    public Question(Integer id, Integer testId, String question, String correct, String wrong) {
        this.id = id;
        this.testId = testId;
        this.question = question;
        this.correct = correct;
        this.wrong = wrong;
    }

    public String getQuestion() {
        return question;
    }

    public Integer getId() {
        return id;
    }

    public Integer getTestId() {
        return testId;
    }

    public String getCorrect() {
        return correct;
    }

    public String getWrong() {
        return wrong;
    }
}
